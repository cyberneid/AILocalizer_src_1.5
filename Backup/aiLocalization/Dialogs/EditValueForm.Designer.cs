namespace Artfulbits.Android.Localization
{
	partial class EditValueForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.richOriginal = new System.Windows.Forms.RichTextBox();
      this.richTranslation = new System.Windows.Forms.RichTextBox();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnSave = new System.Windows.Forms.Button();
      this.grpSplitter = new System.Windows.Forms.GroupBox();
      this.lblResourceKeyInfo = new System.Windows.Forms.Label();
      this.lblResKey = new System.Windows.Forms.Label();
      this.chkSkip = new System.Windows.Forms.CheckBox();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlDark;
      this.splitContainer1.Location = new System.Drawing.Point( 8, 36 );
      this.splitContainer1.Margin = new System.Windows.Forms.Padding( 0 );
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add( this.richOriginal );
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add( this.richTranslation );
      this.splitContainer1.Size = new System.Drawing.Size( 375, 183 );
      this.splitContainer1.SplitterDistance = 89;
      this.splitContainer1.SplitterWidth = 6;
      this.splitContainer1.TabIndex = 2;
      // 
      // richOriginal
      // 
      this.richOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
      this.richOriginal.Enabled = false;
      this.richOriginal.Font = new System.Drawing.Font( "Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 204 ) ) );
      this.richOriginal.Location = new System.Drawing.Point( 0, 0 );
      this.richOriginal.Name = "richOriginal";
      this.richOriginal.ReadOnly = true;
      this.richOriginal.Size = new System.Drawing.Size( 375, 89 );
      this.richOriginal.TabIndex = 0;
      this.richOriginal.Text = "";
      // 
      // richTranslation
      // 
      this.richTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
      this.richTranslation.Font = new System.Drawing.Font( "Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 204 ) ) );
      this.richTranslation.Location = new System.Drawing.Point( 0, 0 );
      this.richTranslation.Name = "richTranslation";
      this.richTranslation.Size = new System.Drawing.Size( 375, 88 );
      this.richTranslation.TabIndex = 0;
      this.richTranslation.Text = "";
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point( 305, 231 );
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "&Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnSave
      // 
      this.btnSave.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnSave.Location = new System.Drawing.Point( 224, 231 );
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size( 75, 23 );
      this.btnSave.TabIndex = 4;
      this.btnSave.Text = "&Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
      // 
      // grpSplitter
      // 
      this.grpSplitter.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.grpSplitter.Location = new System.Drawing.Point( 9, 222 );
      this.grpSplitter.Name = "grpSplitter";
      this.grpSplitter.Size = new System.Drawing.Size( 371, 4 );
      this.grpSplitter.TabIndex = 3;
      this.grpSplitter.TabStop = false;
      // 
      // lblResourceKeyInfo
      // 
      this.lblResourceKeyInfo.AutoSize = true;
      this.lblResourceKeyInfo.Location = new System.Drawing.Point( 9, 13 );
      this.lblResourceKeyInfo.Name = "lblResourceKeyInfo";
      this.lblResourceKeyInfo.Size = new System.Drawing.Size( 105, 13 );
      this.lblResourceKeyInfo.TabIndex = 0;
      this.lblResourceKeyInfo.Text = "Resource key name:";
      // 
      // lblResKey
      // 
      this.lblResKey.AutoSize = true;
      this.lblResKey.Location = new System.Drawing.Point( 121, 13 );
      this.lblResKey.Name = "lblResKey";
      this.lblResKey.Size = new System.Drawing.Size( 63, 13 );
      this.lblResKey.TabIndex = 1;
      this.lblResKey.Text = "<unknown>";
      // 
      // chkSkip
      // 
      this.chkSkip.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
      this.chkSkip.AutoSize = true;
      this.chkSkip.Location = new System.Drawing.Point( 9, 235 );
      this.chkSkip.Name = "chkSkip";
      this.chkSkip.Size = new System.Drawing.Size( 70, 17 );
      this.chkSkip.TabIndex = 6;
      this.chkSkip.Text = "Skip Item";
      this.chkSkip.UseVisualStyleBackColor = true;
      this.chkSkip.CheckedChanged += new System.EventHandler( this.chkSkip_CheckedChanged );
      // 
      // EditValueForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size( 392, 266 );
      this.Controls.Add( this.chkSkip );
      this.Controls.Add( this.lblResKey );
      this.Controls.Add( this.lblResourceKeyInfo );
      this.Controls.Add( this.grpSplitter );
      this.Controls.Add( this.btnSave );
      this.Controls.Add( this.btnCancel );
      this.Controls.Add( this.splitContainer1 );
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size( 400, 300 );
      this.Name = "EditValueForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Edit Values";
      this.splitContainer1.Panel1.ResumeLayout( false );
      this.splitContainer1.Panel2.ResumeLayout( false );
      this.splitContainer1.ResumeLayout( false );
      this.ResumeLayout( false );
      this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.RichTextBox richOriginal;
		private System.Windows.Forms.RichTextBox richTranslation;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.GroupBox grpSplitter;
    private System.Windows.Forms.Label lblResourceKeyInfo;
    private System.Windows.Forms.Label lblResKey;
    private System.Windows.Forms.CheckBox chkSkip;
	}
}