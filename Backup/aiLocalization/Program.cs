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
using System.IO;
using System.Windows.Forms;
#endregion

namespace Artfulbits.Android.Localization
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
      try
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault( false );
        Application.Run( new MainForm() );
      }
      catch( Exception ex )
      {
        MessageBox.Show( ex.Message, "Unhandled Exception" );

        string dir = Path.GetDirectoryName( Application.ExecutablePath );

        using( StreamWriter writer = File.CreateText( Path.Combine( dir, Guid.NewGuid().ToString() + ".log" ) ) )
        {
          writer.WriteLine( ex.Message );
          writer.WriteLine( ex.StackTrace );
        }
      }
		}
	}
}
