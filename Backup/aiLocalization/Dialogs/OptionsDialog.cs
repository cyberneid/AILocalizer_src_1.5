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

#region files usings
using System.Windows.Forms;
using System.Drawing;
#endregion

namespace Artfulbits.Android.Localization
{
  public partial class OptionsDialog : Form
  {
    public bool CreateBackup
    {
      get
      {
        return chkBackup.Checked;
      }
      set
      {
        chkBackup.Checked = value;
      }
    }

    public OptionsDialog()
    {
      InitializeComponent();
    }

    private void OptionsDialog_Load( object sender, System.EventArgs e )
    {
      global::Artfulbits.Android.Localization.Properties.Settings.Default.Reload();

      comboFonts.BeginUpdate();
      comboFonts.Items.Clear();
      
      foreach( FontFamily fam in FontFamily.Families )
      {
        comboFonts.Items.Add( fam.Name );
      }
      
      comboFonts.EndUpdate();

      comboFonts.SelectedItem = global::Artfulbits.Android.Localization.Properties.Settings.Default.PanelFont;
      this.CreateBackup = global::Artfulbits.Android.Localization.Properties.Settings.Default.CreateBackup;
    }

    private void btnOk_Click( object sender, System.EventArgs e )
    {
      global::Artfulbits.Android.Localization.Properties.Settings.Default.PanelFont = ( string )comboFonts.SelectedItem;
      global::Artfulbits.Android.Localization.Properties.Settings.Default.CreateBackup = this.CreateBackup;
      global::Artfulbits.Android.Localization.Properties.Settings.Default.Save();
    }
  }
}
