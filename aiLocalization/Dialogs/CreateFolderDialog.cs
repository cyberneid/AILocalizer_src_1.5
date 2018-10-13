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
using System.IO;
using System.Windows.Forms;
using Artfulbits.Android.Localization.Properties;
#endregion

namespace Artfulbits.Android.Localization
{
  public partial class CreateFolderDialog : Form
  {
    #region Class members
    /// <summary>
    /// Current work directory.
    /// </summary>
    private string strLocalPath;
    #endregion

    #region Class properties
    /// <summary>
    /// Entered new localization folder named.
    /// </summary>
    public string FolderName
    {
      get
      {
        return txtValues.Text + txtLocalization.Text;
      }
    }
    #endregion

    #region Class constructors
    /// <summary>
    /// Initialize instance of CreateFolderDialog class.
    /// </summary>
    public CreateFolderDialog()
      : this( Directory.GetCurrentDirectory() )
    {
    }
    /// <summary>
    /// Initialize instance of CreateFolderDialog class.
    /// </summary>
    /// <param name="path">Set working directory.</param>
    public CreateFolderDialog( string path )
    {
      strLocalPath = path;
      InitializeComponent();
    }
    #endregion

    #region Class events
    /// <summary></summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CreateFolderDialog_Load( object sender, EventArgs e )
    {
      lblInfo.Text = "Auto Translate supports only languages: " +
        string.Join( ", ", Constants.KnownAutoTranslate ) + ".\n\n" +
        "Supported languages are: " + string.Join( ", ", Constants.KnownAutoTranslateNames ) + ".";
    }
    /// <summary></summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void txtLocalization_TextChanged( object sender, EventArgs e )
    {
      bool bExist = Directory.Exists( Path.Combine( strLocalPath, FolderName ) );

      if( bExist )
      {
        lblHelp.Text = Resources.newFolderExistError;
        lblHelp.ForeColor = Color.Red;
        btnOk.Enabled = false;
      }
      else
      {
        lblHelp.Text = Resources.newFolderName;
        lblHelp.ForeColor = Color.Black;
        btnOk.Enabled = true;
      }
    }
    #endregion
  }
}
