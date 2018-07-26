namespace FortniteReplayRepairer
{
    partial class Error
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
            this.errorLabel = new System.Windows.Forms.Label();
            this.errorInfoTextBox = new System.Windows.Forms.RichTextBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.reportIssueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.errorLabel.Location = new System.Drawing.Point(12, 9);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(163, 20);
            this.errorLabel.TabIndex = 0;
            this.errorLabel.Text = "An error occurred in {0}";
            // 
            // errorInfoTextBox
            // 
            this.errorInfoTextBox.Location = new System.Drawing.Point(16, 32);
            this.errorInfoTextBox.Name = "errorInfoTextBox";
            this.errorInfoTextBox.ReadOnly = true;
            this.errorInfoTextBox.Size = new System.Drawing.Size(388, 107);
            this.errorInfoTextBox.TabIndex = 1;
            this.errorInfoTextBox.Text = "";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(329, 145);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // reportIssueButton
            // 
            this.reportIssueButton.Location = new System.Drawing.Point(190, 145);
            this.reportIssueButton.Name = "reportIssueButton";
            this.reportIssueButton.Size = new System.Drawing.Size(133, 23);
            this.reportIssueButton.TabIndex = 3;
            this.reportIssueButton.Text = "Report Issue on Github";
            this.reportIssueButton.UseVisualStyleBackColor = true;
            this.reportIssueButton.Click += new System.EventHandler(this.reportIssueButton_Click);
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 176);
            this.ControlBox = false;
            this.Controls.Add(this.reportIssueButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.errorInfoTextBox);
            this.Controls.Add(this.errorLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Error";
            this.Text = "Error";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.RichTextBox errorInfoTextBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button reportIssueButton;
    }
}