namespace Artfulbits.Android.Localization
{
    partial class CreateFolderDialog
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
          this.txtLocalization = new System.Windows.Forms.TextBox();
          this.lblHelp = new System.Windows.Forms.Label();
          this.txtValues = new System.Windows.Forms.TextBox();
          this.lblInfo = new System.Windows.Forms.Label();
          this.SuspendLayout();
          // 
          // btnCancel
          // 
          this.btnCancel.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.btnCancel.Location = new System.Drawing.Point( 307, 233 );
          this.btnCancel.Name = "btnCancel";
          this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
          this.btnCancel.TabIndex = 4;
          this.btnCancel.Text = "&Cancel";
          this.btnCancel.UseVisualStyleBackColor = true;
          // 
          // btnOk
          // 
          this.btnOk.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
          this.btnOk.Enabled = false;
          this.btnOk.Location = new System.Drawing.Point( 226, 233 );
          this.btnOk.Name = "btnOk";
          this.btnOk.Size = new System.Drawing.Size( 75, 23 );
          this.btnOk.TabIndex = 3;
          this.btnOk.Text = "&OK";
          this.btnOk.UseVisualStyleBackColor = true;
          // 
          // txtLocalization
          // 
          this.txtLocalization.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                      | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.txtLocalization.AutoCompleteCustomSource.AddRange( new string[] {
            "uk",
            "ru"} );
          this.txtLocalization.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
          this.txtLocalization.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
          this.txtLocalization.Location = new System.Drawing.Point( 71, 35 );
          this.txtLocalization.Name = "txtLocalization";
          this.txtLocalization.Size = new System.Drawing.Size( 311, 20 );
          this.txtLocalization.TabIndex = 2;
          this.txtLocalization.TextChanged += new System.EventHandler( this.txtLocalization_TextChanged );
          // 
          // lblHelp
          // 
          this.lblHelp.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                      | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.lblHelp.AutoSize = true;
          this.lblHelp.Location = new System.Drawing.Point( 12, 9 );
          this.lblHelp.Name = "lblHelp";
          this.lblHelp.Size = new System.Drawing.Size( 243, 13 );
          this.lblHelp.TabIndex = 0;
          this.lblHelp.Text = "Enter new localozation folder (example: values-de)";
          // 
          // txtValues
          // 
          this.txtValues.AutoCompleteCustomSource.AddRange( new string[] {
            "values-uk",
            "values-ru"} );
          this.txtValues.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
          this.txtValues.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
          this.txtValues.Enabled = false;
          this.txtValues.Location = new System.Drawing.Point( 15, 35 );
          this.txtValues.Name = "txtValues";
          this.txtValues.Size = new System.Drawing.Size( 56, 20 );
          this.txtValues.TabIndex = 1;
          this.txtValues.TabStop = false;
          this.txtValues.Text = "values-";
          this.txtValues.TextChanged += new System.EventHandler( this.txtLocalization_TextChanged );
          // 
          // lblInfo
          // 
          this.lblInfo.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                      | System.Windows.Forms.AnchorStyles.Left )
                      | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.lblInfo.Location = new System.Drawing.Point( 15, 62 );
          this.lblInfo.Name = "lblInfo";
          this.lblInfo.Size = new System.Drawing.Size( 367, 168 );
          this.lblInfo.TabIndex = 5;
          // 
          // CreateFolderDialog
          // 
          this.AcceptButton = this.btnOk;
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this.btnCancel;
          this.ClientSize = new System.Drawing.Size( 394, 268 );
          this.Controls.Add( this.lblInfo );
          this.Controls.Add( this.txtValues );
          this.Controls.Add( this.txtLocalization );
          this.Controls.Add( this.lblHelp );
          this.Controls.Add( this.btnOk );
          this.Controls.Add( this.btnCancel );
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.MinimumSize = new System.Drawing.Size( 400, 300 );
          this.Name = "CreateFolderDialog";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Create New Folder Dialog";
          this.Load += new System.EventHandler( this.CreateFolderDialog_Load );
          this.ResumeLayout( false );
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtLocalization;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.TextBox txtValues;
        private System.Windows.Forms.Label lblInfo;
    }
}