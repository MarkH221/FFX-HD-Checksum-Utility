using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FFX
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenSave(object sender, EventArgs e)
        {
            using (
                var open = new OpenFileDialog
                           {
                               Title = "Open a decrypted FFX/2 Save",
                               Multiselect = false,
                               CheckFileExists = true
                           })
            {
                if (open.ShowDialog() != DialogResult.OK)

                    return;
                Program.Filepath = open.FileName;
                Program.BuildBuffer();
                MessageBox.Show("New Checksum: " + (BitConverter.ToUInt16(Program.Sum, 0)).ToString("X4").ToUpper() +
                                "\nChecksum Repaired.");
                Close();
            }
        }

        private void OpenHaven(object sender, EventArgs e)
        {
            using (var haven = new Process {StartInfo = {FileName = "http://www.360haven.com"}})
            {
                haven.Start();
            }
        }
    }
}