using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;
using CopyFilesImpl;

namespace CopyDirectoryUI
{
    //[FileIOPermissionAttribute(SecurityAction.PermitOnly, PathDiscovery = "C:\\")]

    public partial class MainForm : Form
    {
        private Copier m_copier;
        private Thread m_copierThread;
        private Thread m_DisplayThread;
        private FolderBrowserDialog m_folderbrowser;

        public MainForm()
        {
            InitializeComponent();
            m_copier = new Copier();
            m_copierThread = new Thread(this.m_copier.PerformCopying);
            m_DisplayThread = new Thread(this.DisplayInfo);
            m_DisplayThread.Start();
            m_folderbrowser = new System.Windows.Forms.FolderBrowserDialog();
            m_folderbrowser.UseDescriptionForTitle = true;
        }

        private void COPY_BTN_Click(object sender, EventArgs e)
        {
            if (m_copierThread.IsAlive)
            {
                string msg = "Please wait until the current operation is terminated.";
                string cpt = "Action already in execution";
                MessageBoxButtons btn = MessageBoxButtons.OK;
                if (MessageBox.Show(msg, cpt, btn) == DialogResult.OK) return;
            }
            m_copierThread = new Thread(this.m_copier.PerformCopying);
            if (SelectFolders())
                m_copierThread.Start();
            else
                MessageBox.Show("No Files selected.", "Invalid selection", MessageBoxButtons.OK);
        }

        private bool SelectFolders()
        {
            m_folderbrowser.Description = "Select Source";
            if (m_folderbrowser.ShowDialog() != DialogResult.OK) return false;
            m_copier.m_source = m_folderbrowser.SelectedPath;

            m_folderbrowser.Description = "Select Destination";
            if (m_folderbrowser.ShowDialog() != DialogResult.OK) return false;
            m_copier.m_dest = m_folderbrowser.SelectedPath;

            return true;
        }

        private void DisplayInfo()
        {
            string content = "Press button to copy contents";
            bool print = false;

            while (true)
            {
                if (m_copierThread.IsAlive)
                {
                    content = "Copying from: " + m_copier.m_currSourceDir + Environment.NewLine;
                    content += "Copying to: " + m_copier.m_currDestinDir + Environment.NewLine;
                    content += "File: " + m_copier.m_currFile + Environment.NewLine;
                    print = true;
                }
                else if(print)
                {
                    content = "Copied elements from " + m_copier.m_source + " to " + m_copier.m_dest + Environment.NewLine;
                    content += "Press button to copy contents";
                    print = false;
                }

                try
                {
                    if (!InvokeRequired)
                        textBox2.Text = content;
                    else
                        Invoke(new Action(() => { textBox2.Text = content; }));
                }
                catch (ObjectDisposedException)
                {
                    break;
                }
            }
        }
    }
}
