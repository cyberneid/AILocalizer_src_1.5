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
using System.Windows.Forms;
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
	}
}
