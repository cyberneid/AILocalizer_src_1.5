#region Copyright ArtfulBits Inc. 2005 - 2009
//
//  Copyright ArtfulBits Inc. 2005 - 2009. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  info@artfulbits.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
//
#endregion

#region file usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using Artfulbits.Android.Localization.Properties;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
#endregion

namespace Artfulbits.Android.Localization
{
    /// <summary></summary>
    public partial class MainForm : Form
    {
        #region Constants
        /// <summary></summary>
        public static string c_ValuesFolder = "values";
        /// <summary></summary>
        private const string c_FolderUp = "..";
        /// <summary></summary>
        private const string c_ManifestName = "AndroidManifest.xml";
        /// <summary></summary>
        private const string c_ResourceFolder = "res";
        /// <summary></summary>
        private const string c_StringTagName = "string";
        /// <summary></summary>
        private const string c_StringArrayTagName = "string-array";
        /// <summary></summary>
        private const string c_NameAttribute = "name";
        /// <summary></summary>
        private const string c_Array = "<ARRAY>";
        /// <summary></summary>
        private const string c_Skipped = "<skip/>";
        /// <summary></summary>
        private const string c_StringSkip = "skip";
        #endregion

        #region Fields
        /// <summary></summary>
        private static readonly Regex s_webpageresult = new Regex(@"<div id=result_box [^>]*>([^<]*)</div>", RegexOptions.Compiled);
        /// <summary>Path on Android localization.</summary>
        private string m_path = string.Empty;
        /// <summary>Path on resource folder.</summary>
        private string m_resourcePath;
        /// <summary>Original localization folder path.</summary>
        private string m_originalValuesPath;
        /// <summary>Selected localization folder path.</summary>
        private string m_valuesPath;
        /// <summary>True - document not saved, otherwise False.</summary>
        private bool m_bDirty;
        /// <summary>Reference on document nodes.</summary>
        private List<ListViewItem> m_root;
        /// <summary>View items.</summary>
        private ListViewItem m_parent;
        #endregion

        #region Constructors
        /// <summary></summary>
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Event handlers
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            global::Artfulbits.Android.Localization.Properties.Settings.Default.Reload();

            ((Bitmap)btnCreateFolder.Image).MakeTransparent();
            ((Bitmap)btnRemoveFile.Image).MakeTransparent();
            ((Bitmap)btnEditExternal.Image).MakeTransparent();

            ApplyFontSettings();
            ShowTranslationNotification(false);
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            global::Artfulbits.Android.Localization.Properties.Settings.Default.Save();
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            comboResourceFile.Items.Clear();
            comboResourceFile.Text = string.Empty;
            comboResourceFolder.Items.Clear();
            comboResourceFolder.Text = string.Empty;

            fbdProjectBrowser.SelectedPath = global::Artfulbits.Android.Localization.Properties.Settings.Default.LastAppFolder;

            DialogResult dr = fbdProjectBrowser.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                // store last folder in settings
                global::Artfulbits.Android.Localization.Properties.Settings.Default.LastAppFolder = fbdProjectBrowser.SelectedPath;
                global::Artfulbits.Android.Localization.Properties.Settings.Default.Save();

                m_path = ValidatePath(fbdProjectBrowser.SelectedPath);

                if (m_path != null)
                {
                    lblProjectPath.Text = m_path;
                    lblProjectPath.ForeColor = Color.Black;
                    m_resourcePath = Path.Combine(m_path, c_ResourceFolder);

                    fileWatcher.Path = m_resourcePath;
                    fileWatcher.EnableRaisingEvents = true;

                    ConsumePath();
                }
                else
                {
                    lblProjectPath.Text = "Enter valid path";
                    lblProjectPath.ForeColor = Color.Red;
                }

                ShowHideCombos();
            }
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboResourceFolder_TextChanged(object sender, EventArgs e)
        {
            // Compare files from both directories (base and selected) and fill list with similar filenames.
            ComboBox cb = sender as ComboBox;

            if (cb != null && !string.IsNullOrEmpty(cb.Text))
            {
                comboResourceFile.Items.Clear();
                comboResourceFile.Text = string.Empty;

                m_originalValuesPath = Path.Combine(m_resourcePath, c_ValuesFolder);
                m_valuesPath = Path.Combine(m_resourcePath, cb.Text);

                string[] files = Directory.GetFiles(m_originalValuesPath);
                string[] filesOriginal = Directory.GetFiles(m_valuesPath);

                foreach (string item in files)
                {
                    string file = Path.GetFileName(item);

                    if (Array.Exists<string>(filesOriginal, delegate (string value)
                   {
                       return (Path.GetFileName(value) == file);
                   }))
                    {
                        comboResourceFile.Items.Add(file);
                    }
                }

                if (comboResourceFile.Items.Count == 1)
                {
                    comboResourceFile.SelectedIndex = 0;
                }

                comboResourceFile.Enabled = true;
            }
        }

        private void setProgressVisible()
        {
            statusTranslate.Visible = false;
            prgTranslation.Visible = false;
            prgTranslation.Maximum = 100;
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboResourceFile_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb != null && !string.IsNullOrEmpty(cb.Text))
            {
                LoadDocuments(cb.Text, m_originalValuesPath, m_valuesPath);
                setProgressVisible();
                Application.DoEvents();
            }
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboResourceFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboResourceFolder_TextChanged(sender, e);
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvStrings_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                ListViewItem item = (lvStrings.SelectedItems.Count > 0) ? lvStrings.SelectedItems[0] : null;

                if (item != null && item.Text == c_FolderUp)
                {
                    lvStrings_DoubleClick(sender, e);
                }
                else // try to find folder up node
                {
                    foreach (ListViewItem sub in lvStrings.Items)
                    {
                        if (sub.Text == c_FolderUp)
                        {
                            lvStrings.BeginUpdate();
                            sub.Selected = true;
                            lvStrings_DoubleClick(sender, e);
                            lvStrings.EndUpdate();

                            break; // found dir and navigation done
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                lvStrings_DoubleClick(sender, e);
            }
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvStrings_DoubleClick(object sender, EventArgs e)
        {
            if (lvStrings.SelectedItems.Count > 0)
            {
                ListViewItem item = lvStrings.SelectedItems[0];

                if (item.Tag != null && item.Tag is List<ListViewItem>) // foldering
                {
                    List<ListViewItem> subnodes = (item.Tag as List<ListViewItem>);

                    m_parent = item;

                    NavigateToFolder(subnodes);
                }
                else // edit value of the element
                {
                    EditSelectedValue(item);
                }

                UpdateToolbar();
            }
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvStrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateToolbar();
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popupActions_Opening(object sender, CancelEventArgs e)
        {
            UpdateToolbar();

            previousEmptyToolStripMenuItem.Enabled = btnPrev.Enabled;
            nextEmptyToolStripMenuItem.Enabled = btnNext.Enabled;
            deleteToolStripMenuItem.Enabled = btnRemoveLine.Enabled;
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextEmptyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNext_Click(sender, e);
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvStrings_DoubleClick(sender, e);
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousEmptyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPrev_Click(sender, e);
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRemoveLine_Click(sender, e);
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyFromOriginalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCopyOrig_Click(sender, e);
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            m_bDirty = false;
            btnSave.Enabled = false;

            SaveDocument();
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ComboBox cb = comboResourceFile;

            if (cb != null && !string.IsNullOrEmpty(cb.Text))
            {
                bool bSave = false;

                if (m_bDirty)
                {
                    DialogResult result = MessageBox.Show("Document not saved. Do you want to save changes before refresh?",
                      "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    bSave = (result == DialogResult.Yes);
                }

                if (bSave)
                {
                    SaveDocument();
                }

                LoadDocuments(cb.Text, m_originalValuesPath, m_valuesPath);
            }
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (lvStrings.SelectedIndices.Count > 0)
            {
                int index = lvStrings.SelectedIndices[0];
                int next = NextEmpty(index);

                if (next >= 0)
                {
                    lvStrings.Items[next].Selected = true;
                }
            }
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (lvStrings.SelectedIndices.Count > 0)
            {
                int index = lvStrings.SelectedIndices[0];
                int prev = PrevEmpty(index);

                if (prev >= 0)
                {
                    lvStrings.Items[prev].Selected = true;
                }
            }
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopyOrig_Click(object sender, EventArgs e)
        {
            if (lvStrings.SelectedItems.Count > 0)
            {
                ListViewItem item = lvStrings.SelectedItems[0];
                bool bOverwrite = true;

                if (!string.IsNullOrEmpty(item.SubItems[2].Text.Trim()))
                {
                    DialogResult result = MessageBox.Show("Do you want to overwrite localization string?!", "Warning",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    bOverwrite = (result == DialogResult.Yes);
                }

                if (bOverwrite)
                {
                    item.SubItems[2].Text = item.SubItems[1].Text;
                    SetDirty();
                }
            }
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddLine_Click(object sender, EventArgs e)
        {
            ListViewItem item = null;
            bool bEdit = false;

            if (IsArray())
            {
                // add item
                item = new ListViewItem(new string[] { m_parent.Text, "", "" });
                lvStrings.Items.Add(item);

                ((List<ListViewItem>)m_parent.Tag).Add(item);

                bEdit = true;
            }
            else
            {
                using (AddKeyDialog dialog = new AddKeyDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        // add item
                        item = new ListViewItem(new string[] { dialog.ElementName, "", "" });
                        lvStrings.Items.Add(item);

                        // create array item
                        if (dialog.CreateArray)
                        {
                            item.Font = new Font(lvStrings.Font, FontStyle.Bold);
                            item.SubItems[1].Text = c_Array;
                            item.Tag = new List<ListViewItem>();

                            bEdit = false;
                        }
                        else
                        {
                            bEdit = true;
                        }

                        item.Selected = true;
                        lvStrings.EnsureVisible(lvStrings.Items.Count - 1);
                        m_root.Add(item);
                    }
                }
            }

            // show edit value dialog
            if (bEdit)
            {
                EditSelectedValue(item);
            }
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveLine_Click(object sender, EventArgs e)
        {
            if (lvStrings.SelectedItems.Count > 0)
            {
                ListViewItem selected = lvStrings.SelectedItems[0];

                if (selected.SubItems[1].Text == string.Empty &&
                    MessageBox.Show(this, "Do you really want to remove element?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    lvStrings.Items.Remove(selected);

                    if (IsArray())
                    {
                        ((List<ListViewItem>)m_parent.Tag).Remove(selected);
                    }
                    else
                    {
                        m_root.Remove(selected);
                    }
                }
            }
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            using (CreateFolderDialog dialog = new CreateFolderDialog(m_resourcePath))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (dialog.FolderName.Length > 0)
                    {
                        string path = Path.Combine(m_resourcePath, dialog.FolderName);

                        //  add new folder
                        Directory.CreateDirectory(path);
                        string values = Path.Combine(m_resourcePath, c_ValuesFolder);

                        // copy files from orginal
                        string[] files = Directory.GetFiles(values);

                        for (int i = 0, nLength = files.Length; i < nLength; i++)
                        {
                            string filename = Path.GetFileName(files[i]);
                            File.Copy(Path.Combine(values, filename), Path.Combine(path, filename), false);
                        }

                        ConsumePath(dialog.FolderName);
                    }
                }
            }
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(m_valuesPath, comboResourceFile.Text);

            DialogResult result = MessageBox.Show("Do you want to delete selected file?\n" + path, "Warning",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    File.Delete(path);

                    // remove item from list
                    comboResourceFile.Items.RemoveAt(comboResourceFile.SelectedIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmAbout about = new frmAbout())
            {
                about.ShowDialog(this);
            }
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditExternal_Click(object sender, EventArgs e)
        {
            String path = Path.Combine(m_valuesPath, comboResourceFile.Text);

            Process.Start(global::Artfulbits.Android.Localization.Properties.Settings.Default.ExternalEditor, path);
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OptionsDialog dialog = new OptionsDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ApplyFontSettings();
                }
            }
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stripTranslate_Click(object sender, EventArgs e)
        {
            string lang = string.Empty;
            string[] parts = comboResourceFolder.Text.Split(new string[] { c_ValuesFolder + "-" },
              StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 0)
            {
                lang = parts[0];

                if (Array.IndexOf(Constants.KnownAutoTranslate, lang) < 0)
                {
                    MessageBox.Show("Auto translation is not allowed for current language", "Error");
                    return;
                }
            }

            if (!workerAutoTranslate.IsBusy && !string.IsNullOrEmpty(lang))
            {
                ShowTranslationNotification(true);

                TranslationContext context = new TranslationContext(lang);

                int length = lvStrings.SelectedItems.Count;

                if (length > 0)
                {
                    foreach (ListViewItem item in lvStrings.SelectedItems)
                    {
                        context.Items.Add(item);
                    }
                }
                else
                {
                    foreach (ListViewItem item in lvStrings.Items)
                    {
                        if (item.SubItems.Count < 3)
                        {
                            item.SubItems.Add("");
                        }

                        if (item.SubItems[2].Text.Length < 1)
                        {
                            context.Items.Add(item);
                        }
                    }
                }

                workerAutoTranslate.RunWorkerAsync(context);
            }
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stripOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start(m_valuesPath);
        }
        #endregion

        #region Helper methods
        /// <summary></summary>
        private void ApplyFontSettings()
        {
            try
            {
                string fontName = global::Artfulbits.Android.Localization.Properties.Settings.Default.PanelFont;
                lvStrings.Font = new Font(new FontFamily(fontName), 9f);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message, "Exception");
                lvStrings.Font = Control.DefaultFont;
            }
        }
        /// <summary></summary>
        /// <param name="file"></param>
        /// <param name="original"></param>
        /// <param name="folder"></param>
        private void LoadDocuments(string file, string original, string folder)
        {
            lvStrings.BeginUpdate();
            lvStrings.Items.Clear();

            string pathOriginal = Path.Combine(original, file);
            string path = Path.Combine(folder, file);
            string oldCaption = this.Text;

            if (File.Exists(path) && File.Exists(pathOriginal))
            {
                // parse both files
                XmlDocument xdocOriginal = new XmlDocument();
                XmlReader readerOriginal = new XmlTextReader(pathOriginal);

                xdocOriginal.Load(readerOriginal);
                XmlNodeList listOriginal = xdocOriginal.GetElementsByTagName(c_StringTagName);
                XmlNodeList listArrayOriginal = xdocOriginal.GetElementsByTagName(c_StringArrayTagName);

                XmlDocument xdoc = new XmlDocument();
                XmlReader reader = new XmlTextReader(path);

                xdoc.Load(reader);
                XmlNodeList list = xdoc.GetElementsByTagName(c_StringTagName);
                XmlNodeList listArray = xdoc.GetElementsByTagName(c_StringArrayTagName);

                // Show their <string\> values
                this.Text = "Please wait while loading files...";
                AddOriginalItems(listOriginal);
                setProgressVisible();
                AddOriginalItems(listArrayOriginal);
                setProgressVisible();
                AddLocalItems(list);
                AddLocalItems(listArray);
                this.Text = oldCaption;
            }

            CreateEmptySubItems();
            RefreshItemsMarkers();

            lvStrings.Enabled = true;
            lvStrings.Sort();

            SaveDocumentRoot();

            lvStrings.EndUpdate();

            stripActions.Enabled = true;
            UpdateToolbar();
        }
        /// <summary></summary>
        private void SaveDocument()
        {
            if (m_root != null)
            {
                CreateBackup();

                string file = comboResourceFile.Text;
                string output = Path.Combine(m_valuesPath, file);

                do
                {
                    try
                    {
                        SaveDocument(output);
                        break;
                    }
                    catch (Exception ex)
                    {
                        DialogResult result = MessageBox.Show("Can not save file due to error: " + ex.Message +
                          "\nDo you want to save file into another location?", "Error",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                        if (result != DialogResult.Yes)
                            break;

                        using (SaveFileDialog save = new SaveFileDialog())
                        {
                            save.FileName = output;

                            result = save.ShowDialog();

                            if (result != DialogResult.OK)
                                break;

                            output = save.FileName;
                        }
                    }
                }
                while (true);
            }
        }
        /// <summary></summary>
        /// <param name="output"></param>
        private void SaveDocument(string output)
        {
            using (XmlTextWriter writer = new XmlTextWriter(output, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;

                writer.WriteStartDocument();
                writer.WriteComment(NormalizeComments(global::Artfulbits.Android.Localization.Properties.Settings.Default.Copyright));

                writer.WriteStartElement("resources");
                writer.WriteAttributeString("xmlns:xliff", "urn:oasis:names:tc:xliff:document:1.2");
                writer.WriteAttributeString("xmlns:android", "http://schemas.android.com/apk/res/android");

                WriteNodes(writer, m_root);

                writer.WriteEndElement();
            }
        }
        /// <summary></summary>
        private void CreateBackup()
        {
            Settings.Default.Reload();

            if (Settings.Default.CreateBackup)
            {
                string file = comboResourceFile.Text;
                string source = Path.Combine(m_valuesPath, file);
                string destination = Path.Combine(m_valuesPath, Path.GetFileNameWithoutExtension(file) + ".bak");

                try
                {
                    File.Copy(source, destination, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Application can not create backup file due to error: " + ex.Message);
                }
            }
        }
        /// <summary></summary>
        /// <param name="writer"></param>
        /// <param name="root"></param>
        private void WriteNodes(XmlWriter writer, List<ListViewItem> root)
        {
            foreach (ListViewItem item in root)
            {
                if (item.Tag != null && item.Tag is List<ListViewItem>) // foldering
                {
                    List<ListViewItem> subnodes = (item.Tag as List<ListViewItem>);

                    writer.WriteStartElement(c_StringArrayTagName);
                    writer.WriteAttributeString("name", item.Name);

                    foreach (ListViewItem sub in subnodes)
                    {
                        writer.WriteComment(NormalizeComments("Original value: " + sub.SubItems[1].Text));

                        writer.WriteStartElement("item");
                        writer.WriteValue(NormalizeText(sub.SubItems[2].Text));
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }
                else
                {
                    writer.WriteComment(NormalizeComments("Original value: " + item.SubItems[1].Text));

                    writer.WriteStartElement(c_StringTagName);
                    writer.WriteAttributeString("name", item.Name);
                    writer.WriteValue(NormalizeText(item.SubItems[2].Text));
                    writer.WriteEndElement();
                }
            }
        }
        /// <summary>Remove "--" from comments. It's not allowed symbol for XML.</summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string NormalizeComments(string text)
        {
            return text.Replace("--", "- - ");
        }
        /// <summary></summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string NormalizeText(string text)
        {
            return text.Replace("\t", "  ");
        }
        /// <summary></summary>
        private void CreateEmptySubItems()
        {
            // create empty subitems for missed elements
            foreach (ListViewItem item in lvStrings.Items)
            {
                for (int i = item.SubItems.Count; i < 3; i++)
                {
                    item.SubItems.Add(string.Empty);
                }

                if (item.Tag != null && item.Tag is List<ListViewItem>)
                {
                    List<ListViewItem> subitems = item.Tag as List<ListViewItem>;

                    foreach (ListViewItem sub in subitems)
                    {
                        for (int i = sub.SubItems.Count; i < 3; i++)
                        {
                            sub.SubItems.Add(string.Empty);
                        }
                    }
                }
            }
        }
        /// <summary></summary>
        private void RefreshItemsMarkers()
        {
            // create empty subitems for missed elements
            foreach (ListViewItem item in lvStrings.Items)
            {
                bool bEmpty = (string.IsNullOrEmpty(item.SubItems[1].Text) ||
                  string.IsNullOrEmpty(item.SubItems[2].Text));

                if (item.Tag != null && item.Tag is List<ListViewItem>)
                {
                    List<ListViewItem> subitems = item.Tag as List<ListViewItem>;

                    foreach (ListViewItem sub in subitems)
                    {
                        bool bEmpty2 = (string.IsNullOrEmpty(sub.SubItems[1].Text) ||
                          string.IsNullOrEmpty(sub.SubItems[2].Text));

                        sub.StateImageIndex = (bEmpty2) ? 0 : -1;

                        bEmpty |= bEmpty2;
                    }
                }

                item.StateImageIndex = (bEmpty) ? 0 : -1;
            }
        }
        /// <summary></summary>
        private void UpdateToolbar()
        {
            btnSave.Enabled = m_bDirty;

            int iSelection = (lvStrings.SelectedIndices.Count > 0) ? lvStrings.SelectedIndices[0] : -1;
            ListViewItem selected = (iSelection != -1) ? lvStrings.SelectedItems[0] : null;

            btnCopyOrig.Enabled = (iSelection != -1);
            btnRemoveLine.Enabled = (iSelection != -1 &&
              string.IsNullOrEmpty(selected.SubItems[1].Text) &&
              !selected.Text.StartsWith(c_FolderUp));

            btnRefresh.Enabled = true;

            btnNext.Enabled = (NextEmpty(iSelection) >= 0);
            btnPrev.Enabled = (PrevEmpty(iSelection) >= 0);

            btnEditExternal.Enabled = btnRemoveFile.Enabled = (!string.IsNullOrEmpty(comboResourceFile.Text) &&
              comboResourceFile.Enabled);

            string[] parts = comboResourceFolder.Text.Split(new string[] { c_ValuesFolder + "-" },
              StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 0)
            {
                // stripTranslate.Enabled = ( Array.IndexOf( Constants.KnownAutoTranslate, parts[ 0 ] ) >= 0 );
            }
        }
        /// <summary>
        /// Adds local items to the ListView
        /// </summary>
        /// <param name="list">Local Items</param>
        private void AddLocalItems(XmlNodeList list)
        {
            int count = 0;
            statusTranslate.Visible = true;
            prgTranslation.Visible = true;
            prgTranslation.Maximum = list.Count;

            foreach (XmlNode node in list)
            {
                string nodename = node.Attributes[c_NameAttribute].Value;
                ListViewItem[] items = lvStrings.Items.Find(nodename, true);
                ListViewItem item = null;

                if (items != null && items.Length > 0)
                {
                    item = items[0];
                }
                else if (!string.IsNullOrEmpty(nodename))
                {
                    item = lvStrings.Items.Add(nodename);
                    item.SubItems.Add(string.Empty); // add empty original
                }

                if (item != null)
                {
                    AddSubItems(node, item);
                }
                count++;
                prgTranslation.Value = count;
                Application.DoEvents();
            }
        }
        /// <summary>Adds original items to the ListView.</summary>
        /// <param name="listOriginal">Original Items collection.</param>
        private void AddOriginalItems(XmlNodeList listOriginal)
        {
            int count = 0;
            statusTranslate.Visible = true;
            prgTranslation.Visible = true;
            prgTranslation.Maximum = listOriginal.Count;
            foreach (XmlNode node in listOriginal)
            {
                string nodename = node.Attributes[c_NameAttribute].Value;

                ListViewItem item = lvStrings.Items.Add(nodename);
                item.Name = nodename;

                AddSubItems(node, item);
                count++;
                prgTranslation.Value = count;
                Application.DoEvents();
            }
        }
        /// <summary>Adds value as a sub item.</summary>
        /// <param name="node">XML node with values</param>
        /// <param name="item">ListViewItem</param>
        private void AddSubItems(XmlNode node, ListViewItem item)
        {
            if (node.Name == c_StringTagName) // simple
            {
                item.SubItems.Add(node.InnerText);
            }
            else if (node.Name == c_StringArrayTagName) // array
            {
                ListViewItem.ListViewSubItem it = item.SubItems.Add(c_Array);
                item.Font = new Font(lvStrings.Font, FontStyle.Bold); // mark in bold fond

                CreateSubNodes(node, item);
            }
        }
        /// <summary></summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private void CreateSubNodes(XmlNode node, ListViewItem item)
        {
            bool bNew = (item.Tag == null);
            string arrayName = node.Attributes["name"].Value;

            List<ListViewItem> items = (item.Tag == null) ?
              new List<ListViewItem>() : (List<ListViewItem>)item.Tag;

            XmlNodeList list = node.SelectNodes("item");
            int iCount = -1;

            foreach (XmlElement element in list)
            {
                iCount++;

                if (bNew)
                {
                    items.Add(new ListViewItem(arrayName));
                }

                items[iCount].SubItems.Add(element.InnerText.Trim());
            }

            item.Tag = items;
        }
        /// <summary>Returns validated path or null.</summary>
        /// <param name="path">The path to the project.</param>
        /// <returns>Path, if it is correct, or null.</returns>
        private string ValidatePath(string path)
        {
            string outPath = null;

            if (File.Exists(Path.Combine(path, c_ManifestName))) // is path ok?
            {
                outPath = path;
            }

            return outPath;
        }
        /// <summary></summary>
        private void ConsumePath()
        {
            ConsumePath(null);
        }
        /// <summary>Consume resource folder.</summary>
        /// <param name="select">Item to select. Set null to select first item in list.</param>
        private void ConsumePath(string select)
        {
            // Scan for all folders in the resource directory that have -uk ending
            string[] dirs = Directory.GetDirectories(Path.Combine(m_path, c_ResourceFolder));
            comboResourceFolder.Items.Clear();
            string values = c_ValuesFolder + "-";

            foreach (string item in dirs)
            {
                string filename = Path.GetFileName(item);

                if (filename.StartsWith(values))
                {
                    comboResourceFolder.Items.Add(filename);
                }
            }

            // select first element
            if (comboResourceFolder.Items.Count > 0)
            {
                if (select != null && select.Length > 0)
                {
                    int nItem = comboResourceFolder.FindString(select);
                    comboResourceFolder.SelectedIndex = nItem;
                }
                else
                {
                    comboResourceFolder.SelectedIndex = 0;
                }
            }
        }
        /// <summary></summary>
        private void ShowHideCombos()
        {
            comboResourceFolder.Enabled = (m_path != null);
            comboResourceFile.Enabled = (m_path != null);
            btnCreateFolder.Enabled = true;
            lvStrings.Enabled = (comboResourceFile.SelectedIndex >= 0);
        }
        /// <summary></summary>
        private void SetDirty()
        {
            m_bDirty = true;

            UpdateToolbar();
        }
        /// <summary></summary>
        private void SaveDocumentRoot()
        {
            m_root = new List<ListViewItem>();

            foreach (ListViewItem item in lvStrings.Items)
            {
                m_root.Add(item);
            }
        }
        /// <summary></summary>
        /// <param name="start"></param>
        /// <returns></returns>
        private int NextEmpty(int start)
        {
            for (int i = Math.Max(start + 1, 0), len = lvStrings.Items.Count; i < len; i++)
            {
                ListViewItem item = lvStrings.Items[i];

                if (string.IsNullOrEmpty(item.SubItems[1].Text) ||
                  string.IsNullOrEmpty(item.SubItems[2].Text))
                {
                    return i;
                }
            }

            return -1;
        }
        /// <summary></summary>
        /// <param name="start"></param>
        /// <returns></returns>
        private int PrevEmpty(int start)
        {
            for (int i = start - 1; i >= 0; i--)
            {
                ListViewItem item = lvStrings.Items[i];

                if (string.IsNullOrEmpty(item.SubItems[1].Text) ||
                  string.IsNullOrEmpty(item.SubItems[2].Text))
                {
                    return i;
                }
            }

            return -1;
        }
        /// <summary>Return <b>True</b> is list show array content, othwerwie false.</summary>
        /// <returns></returns>
        private bool IsArray()
        {
            return (lvStrings.FindItemWithText(c_FolderUp) != null);
        }
        /// <summary></summary>
        /// <param name="item"></param>
        private void EditSelectedValue(ListViewItem item)
        {
            using (EditValueForm form = new EditValueForm())
            {
                form.ResourceKey = item.SubItems[0].Text;
                form.Original = item.SubItems[1].Text;
                form.Translation = item.SubItems[2].Text;

                DialogResult result = form.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    item.StateImageIndex = (form.Translation.Length > 0) ? -1 : 0;
                    item.SubItems[2].Text = form.Translation;

                    SetDirty();
                }
            }
        }
        /// <summary></summary>
        /// <param name="subnodes"></param>
        private void NavigateToFolder(List<ListViewItem> subnodes)
        {
            lvStrings.BeginUpdate();
            lvStrings.Items.Clear();

            // if this is not a top level then show ".." element
            if (subnodes != m_root)
            {
                // NOTE: for proper sorting required non empty subitems
                ListViewItem root = new ListViewItem(new string[] { c_FolderUp, "", "" });
                root.Tag = m_root;

                lvStrings.Items.Add(root);
            }

            foreach (ListViewItem sub in subnodes)
            {
                lvStrings.Items.Add(sub);
            }

            if (lvStrings.SelectedIndices.Count > 0)
            {
                lvStrings.EnsureVisible(lvStrings.SelectedIndices[0]);
            }

            RefreshItemsMarkers();

            lvStrings.EndUpdate();
        }
        /// <summary></summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Percent(int min, int max, int value)
        {
            return (value - min) * 100 / (max - min);
        }
        #endregion

        #region Auto Translation
        /// <summary></summary>
        /// <param name="textToTranslate"></param>
        /// <param name="abbr"></param>
        /// <returns></returns>
        /// 
        public static string TranslateText(string textToTranslate, string abbr)
        {
            const string chave = "trnsl.1.1.20181012T140546Z.33a2fa25e5dbb0eb.083c589d1358e4228b713b6ffb6bc6ea8ded0222";
            string strLangPair = string.Format("en|{0} ", abbr);


            textToTranslate = Uri.EscapeDataString(textToTranslate);

            // generate google translate request
            // http://translate.google.com/translate_a/t?client=t&sl=en&tl=ru&text=some%20text
            string url = String.Format("https://translate.yandex.net/api/v1.5/tr/translate?key=" +
                chave + "&lang=pt&text=" + textToTranslate);

            var request = (HttpWebRequest)WebRequest.Create(url);

            var response = (HttpWebResponse)request.GetResponse();

            string result = new StreamReader(response.GetResponseStream()).ReadToEnd();


            if ((int)response.StatusCode == 200)
            {
                int posicao1, posicao2;
                posicao1 = result.IndexOf("<text>");
                posicao2 = result.IndexOf("</text>");
                result = result.Substring(posicao1 + 6, posicao2 - (posicao1 + 6));
            }


            // find result box and get a text




            return result;
        }

        public String getCultureMeaning(string word, string languagePair)
        {
            int posicao1, posicao2;
            string texto = string.Empty;
            string lang = "en|" + languagePair + "";
            word = Uri.EscapeDataString(word);
            string url = String.Format("http://translate.google.com.br/translate_t?&ie=UTF8&text={0}&langpair={1}", word, lang);

            //Clipboard.SetText(url);
            WebClient webClient = new WebClient();
            //webClient.Encoding = System.Text.Encoding.UTF8;

            string result = webClient.DownloadString(url);

            result = result.Substring(result.IndexOf("<span title=\"") + "<span title=\"".Length);
            result = result.Substring(result.IndexOf(">") + 1);
            result = result.Substring(0, result.IndexOf("</span>"));
            result = System.Net.WebUtility.HtmlDecode(result.Trim());

            System.Web.Mvc.JsonResult j;
             j  = new JsonResult() {
                 Data = result,
                 JsonRequestBehavior = JsonRequestBehavior.AllowGet
                 };

           //  MessageBox.Show( (String) j.Data );

            return result;
        }

        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workerAutoTranslate_DoWork(object sender, DoWorkEventArgs e)
        {
            TranslationContext context = (TranslationContext)e.Argument;
            BackgroundWorker worker = (BackgroundWorker)sender;

            // translate selected items
            for (int i = 0, len = context.Items.Count; i < len; i++)
            {
                ListViewItem lsItem = context.Items[i];

                string toTranslate = lsItem.SubItems[1].Text;
                string result = string.Empty;
                if (this.menuYandex.Checked)
                {
                    result = TranslateText(toTranslate, context.Language);
                }
                else
                {
                     result = getCultureMeaning(toTranslate, "pt-BR");
                }

                worker.ReportProgress(Percent(0, len, i), new TranslationResult(lsItem, result));

                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
            }
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workerAutoTranslate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is TranslationResult)
            {
                // NOTE: text assigning should be done only in main GUI thread
                TranslationResult result = (TranslationResult)e.UserState;
                result.Item.SubItems[2].Text = result.Translation;

                SetDirty();
            }

            prgTranslation.Value = e.ProgressPercentage;
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workerAutoTranslate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Operation was aborted by user", "Abort");
            }
            else if (null != e.Error)
            {
                MessageBox.Show(e.Error.Message, "Error");
            }
            else // completed
            {
                MessageBox.Show("Automatic translation done", "Success");
            }

            ShowTranslationNotification(false);
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransCancel_Click(object sender, EventArgs e)
        {
            if (workerAutoTranslate.IsBusy)
            {
                workerAutoTranslate.CancelAsync();
            }
        }
        /// <summary></summary>
        /// <param name="value"></param>
        private void ShowTranslationNotification(bool value)
        {
            stripTranslateInfo.Visible = value;
            btnTransCancel.Visible = value;
            prgTranslation.Visible = value;
        }
        #endregion

        #region Nested classes
        /// <summary></summary>
        internal class TranslationContext
        {
            /// <summary></summary>
            public readonly List<ListViewItem> Items = new List<ListViewItem>();
            /// <summary></summary>
            public readonly string Language;
            /// <summary></summary>
            /// <param name="lang"></param>
            public TranslationContext(string lang)
            {
                this.Language = lang;
            }
        }
        /// <summary></summary>
        internal class TranslationResult
        {
            /// <summary></summary>
            public readonly string Translation;
            /// <summary></summary>
            public readonly ListViewItem Item;
            /// <summary></summary>
            /// <param name="item"></param>
            /// <param name="value"></param>
            public TranslationResult(ListViewItem item, string value)
            {
                this.Item = item;
                this.Translation = value;
            }
        }
        #endregion

        #region File System Monitoring
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Trace.WriteLine(e.FullPath, "Changed");
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Trace.WriteLine(e.FullPath, "Created");
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Trace.WriteLine(e.FullPath, "Deleted");
        }
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            Trace.WriteLine(e.FullPath, "Renamed");
        }
        #endregion

        private void comboResourceFile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void translateSelectedsItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void translateAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }


}
