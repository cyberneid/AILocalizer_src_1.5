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
  public partial class AddKeyDialog : Form
  {
    #region Class properties
    /// <summary>
    /// New element name.
    /// </summary>
    public string ElementName
    {
      get
      {
        return txtName.Text;
      }
    }
    /// <summary>
    /// Determine if new element is array.
    /// </summary>
    public bool CreateArray
    {
      get
      {
        return chkArray.Checked;
      }
    }
    #endregion

    #region Class constructor
    /// <summary>
    /// Create new instance of AddKeyDialog class.
    /// </summary>
    public AddKeyDialog()
    {
      InitializeComponent();
    }
    #endregion

    #region Class events
    private void txtName_TextChanged( object sender, EventArgs e )
    {
      btnOK.Enabled = ( txtName.Text.Length > 0 );
    }
    #endregion
  }
}
