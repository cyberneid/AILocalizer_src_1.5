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
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Web;
using System.Collections.Specialized;
#endregion

namespace Artfulbits.Android.Localization
{
	public partial class EditValueForm : Form
	{
    public string ResourceKey
    {
      get
      {
        return lblResKey.Text;
      }
      set
      {
        lblResKey.Text = value;
      }
    }

    public string Original
    {
      get
      {
        return richOriginal.Text;
      }
      set
      {
        richOriginal.Text = value;
      }
    }

    public string Translation
    {
      get
      {
        return richTranslation.Text;
      }
      set
      {
        richTranslation.Text = value;
      }
    }

    public bool Skipped
    {
      get
      {
        return chkSkip.Checked;
      }
      set
      {
        chkSkip.Checked = value;
      }
    }

		public EditValueForm()
		{
			InitializeComponent();
		}

    private void btnSave_Click( object sender, EventArgs e )
    {
      this.DialogResult = DialogResult.OK;
      
      Close();
    }

    private void chkSkip_CheckedChanged( object sender, EventArgs e )
    {
      richTranslation.Enabled = !chkSkip.Checked;
    }
        void CutAction(object sender, EventArgs e)
        {
            richTranslation.Cut();
        }

        void CopyAction(object sender, EventArgs e)
        {
            Graphics objGraphics;
            Clipboard.SetData(DataFormats.Rtf, richTranslation.SelectedRtf);
            Clipboard.Clear();
        }

        void PasteAction(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                richTranslation.SelectedRtf
                    = Clipboard.GetData(DataFormats.Rtf).ToString();
            }
        }
        private void richTranslation_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {   //click event
                //MessageBox.Show("you got it!");
                ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
                MenuItem menuItem = new MenuItem("Cut");
                menuItem.Click += new EventHandler(CutAction);
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Copy");
                menuItem.Click += new EventHandler(CopyAction);
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Paste");
                menuItem.Click += new EventHandler(PasteAction);
                contextMenu.MenuItems.Add(menuItem);

                richTranslation.ContextMenu = contextMenu;
            }
        }

        private void EditValueForm_Load(object sender, EventArgs e)
        {
            richTranslation.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTranslation.Text = richOriginal.Text;
            Clipboard.SetText(richTranslation.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const String url = "https://translate.google.com.br/?hl=pt-BR#auto/pt/";

            String parametros = Uri.EscapeDataString( richTranslation.Text);
            
            Process.Start("chrome.exe", url + parametros);
        }
    }
}
