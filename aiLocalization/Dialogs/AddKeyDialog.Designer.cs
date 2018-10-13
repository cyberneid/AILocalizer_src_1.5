namespace Artfulbits.Android.Localization
{
    partial class AddKeyDialog
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
          this.btnOK = new System.Windows.Forms.Button();
          this.lblName = new System.Windows.Forms.Label();
          this.txtName = new System.Windows.Forms.TextBox();
          this.chkArray = new System.Windows.Forms.CheckBox();
          this.SuspendLayout();
          // 
          // btnCancel
          // 
          this.btnCancel.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.btnCancel.Location = new System.Drawing.Point( 230, 80 );
          this.btnCancel.Name = "btnCancel";
          this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
          this.btnCancel.TabIndex = 4;
          this.btnCancel.Text = "&Cancel";
          this.btnCancel.UseVisualStyleBackColor = true;
          // 
          // btnOK
          // 
          this.btnOK.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
          this.btnOK.Enabled = false;
          this.btnOK.Location = new System.Drawing.Point( 149, 80 );
          this.btnOK.Name = "btnOK";
          this.btnOK.Size = new System.Drawing.Size( 75, 23 );
          this.btnOK.TabIndex = 3;
          this.btnOK.Text = "&Ok";
          this.btnOK.UseVisualStyleBackColor = true;
          // 
          // lblName
          // 
          this.lblName.AutoSize = true;
          this.lblName.Location = new System.Drawing.Point( 9, 9 );
          this.lblName.Name = "lblName";
          this.lblName.Size = new System.Drawing.Size( 104, 13 );
          this.lblName.TabIndex = 0;
          this.lblName.Text = "Enter element name:";
          // 
          // txtName
          // 
          this.txtName.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                      | System.Windows.Forms.AnchorStyles.Right ) ) );
          this.txtName.Font = new System.Drawing.Font( "Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte )( 204 ) ) );
          this.txtName.Location = new System.Drawing.Point( 12, 25 );
          this.txtName.Name = "txtName";
          this.txtName.Size = new System.Drawing.Size( 293, 24 );
          this.txtName.TabIndex = 1;
          this.txtName.TextChanged += new System.EventHandler( this.txtName_TextChanged );
          // 
          // chkArray
          // 
          this.chkArray.AutoSize = true;
          this.chkArray.Location = new System.Drawing.Point( 12, 55 );
          this.chkArray.Name = "chkArray";
          this.chkArray.Size = new System.Drawing.Size( 144, 17 );
          this.chkArray.TabIndex = 2;
          this.chkArray.Text = "Create array (<ARRAY> )";
          this.chkArray.UseVisualStyleBackColor = true;
          // 
          // AddKeyDialog
          // 
          this.AcceptButton = this.btnOK;
          this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this.btnCancel;
          this.ClientSize = new System.Drawing.Size( 317, 115 );
          this.Controls.Add( this.chkArray );
          this.Controls.Add( this.txtName );
          this.Controls.Add( this.lblName );
          this.Controls.Add( this.btnOK );
          this.Controls.Add( this.btnCancel );
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "AddKeyDialog";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Add Key Dialog";
          this.ResumeLayout( false );
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkArray;
    }
}