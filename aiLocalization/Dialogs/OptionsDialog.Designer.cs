namespace Artfulbits.Android.Localization
{
    partial class OptionsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          this.btnCancel = new System.Windows.Forms.Button();
          this.btnOk = new System.Windows.Forms.Button();
          this.chkBackup = new System.Windows.Forms.CheckBox();
          this.lblFont = new System.Windows.Forms.Label();
          this.comboFonts = new System.Windows.Forms.ComboBox();
          this.SuspendLayout();
          // 
          // btnCancel
          // 
          this.btnCancel.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.btnCancel.Location = new System.Drawing.Point( 167, 96 );
          this.btnCancel.Name = "btnCancel";
          this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
          this.btnCancel.TabIndex = 0;
          this.btnCancel.Text = "&Cancel";
          this.btnCancel.UseVisualStyleBackColor = true;
          // 
          // btnOk
          // 
          this.btnOk.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
          this.btnOk.Location = new System.Drawing.Point( 86, 96 );
          this.btnOk.Name = "btnOk";
          this.btnOk.Size = new System.Drawing.Size( 75, 23 );
          this.btnOk.TabIndex = 0;
          this.btnOk.Text = "&OK";
          this.btnOk.UseVisualStyleBackColor = true;
          this.btnOk.Click += new System.EventHandler( this.btnOk_Click );
          // 
          // chkBackup
          // 
          this.chkBackup.AutoSize = true;
          this.chkBackup.Location = new System.Drawing.Point( 12, 12 );
          this.chkBackup.Name = "chkBackup";
          this.chkBackup.Size = new System.Drawing.Size( 172, 17 );
          this.chkBackup.TabIndex = 0;
          this.chkBackup.Text = "Create backup for editable files";
          this.chkBackup.UseVisualStyleBackColor = true;
          // 
          // lblFont
          // 
          this.lblFont.AutoSize = true;
          this.lblFont.Location = new System.Drawing.Point( 12, 41 );
          this.lblFont.Name = "lblFont";
          this.lblFont.Size = new System.Drawing.Size( 58, 13 );
          this.lblFont.TabIndex = 2;
          this.lblFont.Text = "Panel font:";
          // 
          // comboFonts
          // 
          this.comboFonts.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                      | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.comboFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.comboFonts.FormattingEnabled = true;
          this.comboFonts.Location = new System.Drawing.Point( 15, 57 );
          this.comboFonts.Name = "comboFonts";
          this.comboFonts.Size = new System.Drawing.Size( 227, 21 );
          this.comboFonts.TabIndex = 3;
          // 
          // OptionsDialog
          // 
          this.AcceptButton = this.btnOk;
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this.btnCancel;
          this.ClientSize = new System.Drawing.Size( 254, 131 );
          this.Controls.Add( this.chkBackup );
          this.Controls.Add( this.comboFonts );
          this.Controls.Add( this.lblFont );
          this.Controls.Add( this.btnOk );
          this.Controls.Add( this.btnCancel );
          this.Name = "OptionsDialog";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Options";
          this.Load += new System.EventHandler( this.OptionsDialog_Load );
          this.ResumeLayout( false );
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkBackup;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.ComboBox comboFonts;
    }
}