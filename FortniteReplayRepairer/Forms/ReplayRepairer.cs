using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FortniteReplayRepairer.Helpers;
using FortniteReplayRepairer.Models;
using FortniteReplayRepairer.Extensions;

namespace FortniteReplayRepairer.Forms
{
    public partial class ReplayRepairer : Form
    {
        private const int REPLAY_BYTES_OFFSET = 16;
        private byte[] versionBuffer = new byte[3];
        private Regex unsavedReplayRegex = new Regex(@"UnsavedReplay-\d{4}\.(0[1-9]|1[0-2])\.(0\d|1\d|2\d|3[0-1])-([0-1]\d|2[0-3]).[0-5]\d.[0-5]\d");
        private readonly string demosDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"FortniteGame\Saved\Demos");

        public ReplayRepairer() => InitializeComponent();

        #region Toolbar Option Handlers
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void faqToolStripMenuItem_Click(object sender, EventArgs e) => new FAQ().ShowDialog();

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fortnite Replay Repairer is a simple program that allows you to repair corrupted replay files.\r\n\r\nCreated by Thomas Upson\r\nhttps://github.com/tomupson",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        #endregion

        private async Task ReadVersionBytesAsync(string fileName)
        {
            versionBuffer = await StreamHelper.ReadBytesAsync(fileName, REPLAY_BYTES_OFFSET, versionBuffer.Length);
        }

        private async void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog browse = new OpenFileDialog
            {
                Filter = "Replay Files (*.replay) | *.replay",
                InitialDirectory = demosDirectory
            };

            if (browse.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await Task.Run(() => ReadVersionBytesAsync(browse.FileName));
                } catch (Exception ex)
                {
                    new Error(new FormExceptionDetails
                    {
                        SourceForm = this,
                        Exception = ex
                    }).ShowDialog();
                    Environment.Exit(0);
                }
            }

            validReplayFileTextbox.Text = browse.FileName;
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            string validReplayFilePath = validReplayFileTextbox.Text;
            if (string.IsNullOrWhiteSpace(validReplayFilePath) || !File.Exists(validReplayFilePath)) return;

            if (!Directory.Exists(demosDirectory))
            {
                new Error(new FormExceptionDetails
                {
                    SourceForm = this,
                    Exception = new IOException($"The demos directory {demosDirectory} does not exist.\r\nIf you have your demos directory in another location, please report this issue using the button below.")
                }).ShowDialog();
                Environment.Exit(0);
            }

            string[] filePaths = Directory.GetFiles(demosDirectory, "*.replay", SearchOption.TopDirectoryOnly);

            conversionProgressBar.Value = 0;
            conversionProgressBar.Maximum = filePaths.Length;

            bool convertOnlyNamed = convertOnlyNamedCheckbox.Checked;
            string backupDirectoryPath = Path.Combine(demosDirectory, "Backup");

            try
            {
                DirectoryHelper.GetOrCreateDirectory(backupDirectoryPath);
            } catch (IOException ex)
            {
                new Error(new FormExceptionDetails
                {
                    SourceForm = this,
                    Exception = ex
                }).ShowDialog();
                Environment.Exit(0);
            }

            try
            {
                // async not necessarily required here, as the lambda function here is being executed on some arbitrary thread other than the UI thread.
                // So if async is removed, and WriteBytesAsync would run synchronously and only block the random thread-pool thread. But hey, why not.
                await Task.Run(async () =>
                {
                    foreach (string filePath in filePaths)
                    {
                        FileInfo file = new FileInfo(filePath);

                        if (convertOnlyNamed && unsavedReplayRegex.Match(Path.GetFileNameWithoutExtension(file.FullName)).Success)
                        {
                            conversionProgressBar.InvokeMember("Perform Step");
                            return;
                        }

                        string backupFilePath = Path.Combine(backupDirectoryPath, file.Name);
                        if (File.Exists(backupFilePath))
                        {
                            File.Delete(backupFilePath);
                        }

                        file.CopyTo(backupFilePath);

                        await StreamHelper.WriteBytesAsync(filePath, versionBuffer, REPLAY_BYTES_OFFSET);

                        conversionProgressBar.InvokeMember("PerformStep");
                    }
                });
            } catch (Exception ex)
            {
                new Error(new FormExceptionDetails
                {
                    SourceForm = this,
                    Exception = ex
                }).ShowDialog();
                Environment.Exit(0);
            }
        }
    }
}