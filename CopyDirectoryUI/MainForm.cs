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
using System.IO;
using CopyFilesImpl;

namespace CopyDirectoryUI
{
    public partial class MainForm : Form
    {
        private Copier m_copier;
        private Thread m_copierThread;
        private Thread m_DisplayThread;
        private FolderBrowserDialog m_folderbrowser;

        public MainForm()
        {
            InitializeComponent();
            PROG_COPY.Hide();
            m_copier = new Copier();

            m_copierThread = new Thread(this.m_copier.PerformCopying);

            m_DisplayThread = new Thread(this.DisplayInfo);
            m_DisplayThread.Start();

            m_folderbrowser = new System.Windows.Forms.FolderBrowserDialog();
            m_folderbrowser.UseDescriptionForTitle = true;
        }

        private void COPY_BTN_Click(object sender, EventArgs e)
        {
            m_copier.m_AbortCopying = false;

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

            PROG_COPY.Show();
            PROG_COPY.Maximum = Directory.GetFiles(m_copier.m_source, "*.*", SearchOption.AllDirectories).Count();
            return true;
        }

        private void DisplayInfo()
        {
            string content = "Press button to copy contents";
            bool f_print = false;

            while (true)
            {
                if (m_copierThread.IsAlive)
                {
                    content = "Copying from: " + m_copier.m_currSourceDir + Environment.NewLine;
                    content += "Copying to: " + m_copier.m_currDestinDir + Environment.NewLine;
                    content += "File: " + m_copier.m_currFile + Environment.NewLine;
                    f_print = true;
                }
                else if(f_print)
                {
                    Invoke(new Action(() => { PROG_COPY.Hide(); }));
                    content = "Copied " + m_copier.m_elementsCopied + " of " + m_copier.m_elementsCount + " elements";
                    content += Environment.NewLine;
                    content += "Source: " + m_copier.m_source + Environment.NewLine;
                    content += "Destination: " + m_copier.m_dest;
                    content += Environment.NewLine + Environment.NewLine;
                    content += "Press button to copy contents";
                    f_print = false;
                }

                try
                {
                    if (!InvokeRequired)
                    {
                        textBox2.Text = content;
                        PROG_COPY.Value = m_copier.m_elementsCopied;
                    }
                    else
                    {
                        Invoke(new Action(() => { textBox2.Text = content; }));
                        Invoke(new Action(() => { PROG_COPY.Value = m_copier.m_elementsCopied; }));
                    }
                }
                catch (ObjectDisposedException)
                {
                    break;
                }
            }
        }

        private void BTN_STOP_Click(object sender, EventArgs e)
        {
            m_copier.m_AbortCopying = true;
        }
    }
}
