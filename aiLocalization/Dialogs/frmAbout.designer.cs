namespace Artfulbits.Android.Localization
{
  partial class frmAbout
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Windows Host Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmAbout ) );
      this.btnOK = new System.Windows.Forms.Button();
      this.imgLogo = new System.Windows.Forms.PictureBox();
      this.lblDevelopers = new System.Windows.Forms.Label();
      this.lblCopyRight = new System.Windows.Forms.Label();
      this.lblVersion = new System.Windows.Forms.Label();
      ( ( System.ComponentModel.ISupportInitialize )( this.imgLogo ) ).BeginInit();
      this.SuspendLayout();
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.btnOK.BackColor = System.Drawing.SystemColors.Control;
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.Location = new System.Drawing.Point( 321, 140 );
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size( 75, 23 );
      this.btnOK.TabIndex = 0;
      this.btnOK.Text = "&OK";
      this.btnOK.UseVisualStyleBackColor = false;
      // 
      // imgLogo
      // 
      this.imgLogo.Image = ( ( System.Drawing.Image )( resources.GetObject( "imgLogo.Image" ) ) );
      this.imgLogo.Location = new System.Drawing.Point( 4, 4 );
      this.imgLogo.Name = "imgLogo";
      this.imgLogo.Size = new System.Drawing.Size( 203, 130 );
      this.imgLogo.TabIndex = 1;
      this.imgLogo.TabStop = false;
      // 
      // lblDevelopers
      // 
      this.lblDevelopers.AutoSize = true;
      this.lblDevelopers.Location = new System.Drawing.Point( 213, 9 );
      this.lblDevelopers.Name = "lblDevelopers";
      this.lblDevelopers.Size = new System.Drawing.Size( 122, 52 );
      this.lblDevelopers.TabIndex = 1;
      this.lblDevelopers.Text = "Developers names:\r\n- Oleksandr Kucherenko\r\n- Oleh Baydalka\r\n- Maxim Kravtsov\r\n";
      // 
      // lblCopyRight
      // 
      this.lblCopyRight.AutoSize = true;
      this.lblCopyRight.Location = new System.Drawing.Point( 213, 108 );
      this.lblCopyRight.Name = "lblCopyRight";
      this.lblCopyRight.Size = new System.Drawing.Size( 167, 26 );
      this.lblCopyRight.TabIndex = 2;
      this.lblCopyRight.Text = "Copyright: ArtfulBits (c) 2005-2009\r\nAll rights reserved.";
      // 
      // lblVersion
      // 
      this.lblVersion.AutoSize = true;
      this.lblVersion.Location = new System.Drawing.Point( 1, 145 );
      this.lblVersion.Name = "lblVersion";
      this.lblVersion.Size = new System.Drawing.Size( 62, 13 );
      this.lblVersion.TabIndex = 3;
      this.lblVersion.Text = "Version: {0}";
      // 
      // frmAbout
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.CancelButton = this.btnOK;
      this.ClientSize = new System.Drawing.Size( 408, 175 );
      this.Controls.Add( this.lblVersion );
      this.Controls.Add( this.lblCopyRight );
      this.Controls.Add( this.lblDevelopers );
      this.Controls.Add( this.imgLogo );
      this.Controls.Add( this.btnOK );
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size( 300, 200 );
      this.Name = "frmAbout";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "About...";
      this.Load += new System.EventHandler( this.frmAbout_Load );
      ( ( System.ComponentModel.ISupportInitialize )( this.imgLogo ) ).EndInit();
      this.ResumeLayout( false );
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.PictureBox imgLogo;
    private System.Windows.Forms.Label lblDevelopers;
    private System.Windows.Forms.Label lblCopyRight;
    private System.Windows.Forms.Label lblVersion;
  }
}