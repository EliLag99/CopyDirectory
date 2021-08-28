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
        //Objects
        private Copier m_copier;
        private Thread m_copierThread;
        private Thread m_DisplayThread;
        private FolderBrowserDialog m_folderbrowser;

        private string m_source;
        private string m_destin;

        //Flags
        private bool f_newDir;

        public MainForm()
        {
            InitializeComponent();
            PROG_COPY.Hide();
            m_copier = new Copier();

            m_DisplayThread = new Thread(this.DisplayInfo);
            m_DisplayThread.Start();

            m_folderbrowser = new System.Windows.Forms.FolderBrowserDialog();
            m_folderbrowser.UseDescriptionForTitle = true;

            f_newDir = false;
        }

        private void COPY_BTN_Click(object sender, EventArgs e)
        {
            m_copier.F_abortCopying = false;

            if (m_copierThread != null && m_copierThread.IsAlive)
            {
                string msg = "Please wait until the current operation is terminated.";
                string cpt = "Action already in execution";
                MessageBoxButtons btn = MessageBoxButtons.OK;
                if (MessageBox.Show(msg, cpt, btn) == DialogResult.OK) return;
            }

            if (SelectFolders())
            {
                m_copierThread = new Thread(() => this.m_copier.PerformCopying(m_source, m_destin, CBOX_OVERWRITE.Checked));
                m_copierThread.Start();
            }
            else
                MessageBox.Show("No Files selected.", "Invalid selection", MessageBoxButtons.OK);
        }

        private bool SelectFolders()
        {
            m_folderbrowser.Description = "Select Source";
            if (m_folderbrowser.ShowDialog() != DialogResult.OK) return false;
            m_source = m_folderbrowser.SelectedPath;

            m_folderbrowser.Description = "Select Destination";
            if (m_folderbrowser.ShowDialog() != DialogResult.OK) return false;
            m_destin = m_folderbrowser.SelectedPath;

            f_newDir = true;
            return true;
        }

        private void DisplayInfo()
        {
            string content = "Press button to copy contents";
            bool f_print = false;

            while (true)
            {
                if (m_copierThread != null && m_copierThread.IsAlive)
                {
                    content = "Copying from: " + m_copier.M_currSourceDir + Environment.NewLine;
                    content += "Copying to: " + m_copier.M_currDestinDir + Environment.NewLine + Environment.NewLine;
                    content += "Element " + m_copier.M_elementsCopied + " of " + m_copier.M_elementsCount + Environment.NewLine;
                    content += "File: " + m_copier.M_currFile;
                    content += m_copier.F_abortCopying ? Environment.NewLine + "Aborting, copying last element to avoid file corruption" : "";
                    f_print = true;
                }
                else if(f_print)
                {
                    Invoke(new Action(() => { PROG_COPY.Hide(); }));
                    content = "Copied " + m_copier.M_elementsCopied + " of " + m_copier.M_elementsCount + " elements";
                    content += Environment.NewLine;
                    content += "Source: " + m_copier.M_source + Environment.NewLine;
                    content += "Destination: " + m_copier.M_dest;
                    content += Environment.NewLine + Environment.NewLine;
                    content += "Press button to copy contents";
                    f_print = false;
                }

                try
                {
                    if (f_newDir)
                    {
                        Invoke(new Action(() => { PROG_COPY.Show(); }));
                        Invoke(new Action(() => { PROG_COPY.Maximum = Directory.GetFiles(m_copier.M_source, "*.*", SearchOption.AllDirectories).Count(); }));
                        f_newDir = false;
                    }
                    Invoke(new Action(() => { textBox2.Text = content; }));
                    Invoke(new Action(() => { PROG_COPY.Value = m_copier.M_elementsCopied; }));
                }
                catch (ObjectDisposedException)
                {
                    break;
                }
            }
        }

        private void BTN_STOP_Click(object sender, EventArgs e)
        {
            m_copier.F_abortCopying = true;
        }
    }
}
