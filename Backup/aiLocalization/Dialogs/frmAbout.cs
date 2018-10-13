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
using System;
using System.Reflection;
using System.Windows.Forms;
#endregion

namespace Artfulbits.Android.Localization
{
  /// <summary></summary>
  public partial class frmAbout : Form
  {
    #region Class properties
    /// <summary>
    /// Extract current assembly version for menu displaying.
    /// </summary>
    private string MenuCurrentVersion
    {
      get
      {
        return string.Format( "Version: {0}",
          Assembly.GetExecutingAssembly().GetName().Version );
      }
    }
    #endregion

    #region Class constructor
    /// <summary></summary>
    public frmAbout()
    {
      InitializeComponent();
    }
    #endregion

    #region Class event handlers
    /// <summary></summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmAbout_Load( object sender, EventArgs e )
    {
      lblVersion.Text = this.MenuCurrentVersion;
    }
    #endregion
  }
}