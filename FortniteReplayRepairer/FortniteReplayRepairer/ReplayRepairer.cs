using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using FortniteReplayRepairer.Extensions;
using FortniteReplayRepairer.Models;

namespace FortniteReplayRepairer
{
    public partial class ReplayRepairer : Form
    {
        // The version is stored at the 16th, 17th and 18th bytes in replay files.
        private byte[] versionBuffer = new byte[3];
        // Someone please find me a better regex for matching unsaved replay files.
        private Regex unsavedReplayRegex = new Regex(@"UnsavedReplay-\d{4}\.(0[1-9]|1[0-2])\.(0\d|1\d|2\d|3[0-1])-([0-1]\d|2[0-3]).[0-5]\d.[0-5]\d");
        private string demosDirectory = Path.Combine($"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}", @"..\Local\FortniteGame\Saved\Demos");

        public ReplayRepairer()
        {
            InitializeComponent();
        }

        #region Toolbar Option Handlers
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void faqToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FAQ().ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fortnite Replay Repairer is a simple program that allows you to repair corrupted replay files.\r\n\r\n© Thomas Upson", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void browseButton_Click(object sender, EventArgs e)
        {
            var browse = new OpenFileDialog
            {
                Filter = "Replay Files (*.replay) | *.replay",
                InitialDirectory = demosDirectory
            };

            if (browse.ShowDialog() == DialogResult.OK)
            {
                string replayFileName = browse.FileName;
                try
                {
                    using (var stream = new FileStream(replayFileName, FileMode.Open, FileAccess.Read))
                    {
                        int amount = 0;
                        stream.Position = 16;

                        do
                        {
                            amount += stream.Read(versionBuffer, amount, 3 - amount);
                        } while (amount != 3 && stream.Position < stream.Length);
                    }
                }
                catch (IOException ex)
                {
                    new Error(new FormExceptionDetails
                    {
                        SourceForm = this,
                        Exception = ex
                    }).ShowDialog();
                    Environment.Exit(0);
                }

                validReplayFileTextbox.Text = replayFileName;
            }
        }

        private void startButton_Click(object sender, EventArgs e) => new Thread(() =>
        {
            string validReplayFile = validReplayFileTextbox.GetPropertyValue("Text") as string;
            if (string.IsNullOrEmpty(validReplayFile) || !File.Exists(validReplayFile)) return;

            if (!Directory.Exists(demosDirectory))
            {
                new Error(new FormExceptionDetails
                {
                    SourceForm = this,
                    Exception = new IOException($"The demos directory {demosDirectory} does not exist.\r\nIf you have your demos directory in another location, please report this issue using the button below.")
                }).ShowDialog();
                Environment.Exit(0);
            }

            string[] files = Directory.GetFiles(demosDirectory, "*.replay", SearchOption.TopDirectoryOnly);
            if (files.Length == 0) return;

            conversionProgressBar.SetPropertyValue("Maximum", files.Length);

            bool convertOnlyNamed = (bool)convertOnlyNamedCheckbox.GetPropertyValue("Checked");
            string backupDirectory = Path.Combine(demosDirectory, "Backups");

            if (!Directory.Exists(backupDirectory))
            {
                try
                {
                    Directory.CreateDirectory(backupDirectory);
                }
                catch (IOException ex)
                {
                    new Error(new FormExceptionDetails
                    {
                        SourceForm = this,
                        Exception = ex
                    }).ShowDialog();
                    Environment.Exit(0);
                }
            }
            
            foreach (string file in files)
            {
                var fileInfo = new FileInfo(file);

                if (convertOnlyNamed && unsavedReplayRegex.Match(Path.GetFileNameWithoutExtension(fileInfo.Name)).Success)
                {
                    conversionProgressBar.InvokeMember("PerformStep", null);
                    continue;
                }

                try
                {
                    string backupFilePath = Path.Combine(backupDirectory, fileInfo.Name);
                    if (File.Exists(backupFilePath))
                    {
                        File.Delete(backupFilePath);
                    }

                    fileInfo.CopyTo(backupFilePath);

                    using (var stream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite))
                    {
                        stream.Position = 16;
                        stream.Write(versionBuffer, 0, versionBuffer.Length);
                    }
                }
                catch (IOException ex)
                {
                    new Error(new FormExceptionDetails
                    {
                        SourceForm = this,
                        Exception = ex
                    }).ShowDialog();
                    Environment.Exit(0);
                }

                conversionProgressBar.InvokeMember("PerformStep", null);
            }
        }).Start();
    }
}