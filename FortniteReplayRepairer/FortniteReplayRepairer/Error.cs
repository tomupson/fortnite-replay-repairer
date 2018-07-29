using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using FortniteReplayRepairer.Models;

namespace FortniteReplayRepairer
{
    public partial class Error : Form
    {
        public Error()
        {
            InitializeComponent();
            Icon = SystemIcons.Error;
        }

        public Error(FormExceptionDetails formExceptionDetails) : this()
        {
            errorLabel.Text = string.Format(errorLabel.Text, formExceptionDetails.SourceForm.Text);
            errorInfoTextBox.Text = formExceptionDetails.Exception.Message;
            formExceptionDetails.SourceForm.Hide();
        }

        private void reportIssueButton_Click(object sender, EventArgs e) => Process.Start("https://github.com/UppyMeister/FortniteReplayRepairer/issues/new");

        private void exitButton_Click(object sender, EventArgs e) => Environment.Exit(0);
    }
}