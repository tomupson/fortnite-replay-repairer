namespace FortniteReplayRepairer.Forms
{
    partial class ReplayRepairer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplayRepairer));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fAQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validReplayFileLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.conversionProgressBar = new System.Windows.Forms.ProgressBar();
            this.startButton = new System.Windows.Forms.Button();
            this.validReplayFileTextbox = new System.Windows.Forms.RichTextBox();
            this.convertOnlyNamedCheckbox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(407, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fAQToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // fAQToolStripMenuItem
            // 
            this.fAQToolStripMenuItem.Enabled = false;
            this.fAQToolStripMenuItem.Name = "fAQToolStripMenuItem";
            this.fAQToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fAQToolStripMenuItem.Text = "FAQ";
            this.fAQToolStripMenuItem.Click += new System.EventHandler(this.FaqToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // validReplayFileLabel
            // 
            this.validReplayFileLabel.AutoSize = true;
            this.validReplayFileLabel.Location = new System.Drawing.Point(12, 24);
            this.validReplayFileLabel.Name = "validReplayFileLabel";
            this.validReplayFileLabel.Size = new System.Drawing.Size(85, 13);
            this.validReplayFileLabel.TabIndex = 14;
            this.validReplayFileLabel.Text = "Valid Replay File";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(315, 40);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 22);
            this.browseButton.TabIndex = 16;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // conversionProgressBar
            // 
            this.conversionProgressBar.Location = new System.Drawing.Point(96, 68);
            this.conversionProgressBar.Name = "conversionProgressBar";
            this.conversionProgressBar.Size = new System.Drawing.Size(294, 23);
            this.conversionProgressBar.Step = 1;
            this.conversionProgressBar.TabIndex = 17;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(15, 68);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 18;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // validReplayFileTextbox
            // 
            this.validReplayFileTextbox.Location = new System.Drawing.Point(15, 40);
            this.validReplayFileTextbox.Multiline = false;
            this.validReplayFileTextbox.Name = "validReplayFileTextbox";
            this.validReplayFileTextbox.ReadOnly = true;
            this.validReplayFileTextbox.Size = new System.Drawing.Size(294, 22);
            this.validReplayFileTextbox.TabIndex = 15;
            this.validReplayFileTextbox.Text = "";
            // 
            // convertOnlyNamedCheckbox
            // 
            this.convertOnlyNamedCheckbox.AutoSize = true;
            this.convertOnlyNamedCheckbox.Checked = true;
            this.convertOnlyNamedCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.convertOnlyNamedCheckbox.Location = new System.Drawing.Point(15, 97);
            this.convertOnlyNamedCheckbox.Name = "convertOnlyNamedCheckbox";
            this.convertOnlyNamedCheckbox.Size = new System.Drawing.Size(163, 17);
            this.convertOnlyNamedCheckbox.TabIndex = 19;
            this.convertOnlyNamedCheckbox.Text = "Only repair named replay files";
            this.convertOnlyNamedCheckbox.UseVisualStyleBackColor = true;
            // 
            // ReplayRepairer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 123);
            this.Controls.Add(this.convertOnlyNamedCheckbox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.conversionProgressBar);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.validReplayFileTextbox);
            this.Controls.Add(this.validReplayFileLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReplayRepairer";
            this.Text = "Replay Repairer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fAQToolStripMenuItem;
        private System.Windows.Forms.Label validReplayFileLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.ProgressBar conversionProgressBar;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.RichTextBox validReplayFileTextbox;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox convertOnlyNamedCheckbox;
    }
}