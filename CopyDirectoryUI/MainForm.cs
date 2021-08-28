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
    [FileIOPermissionAttribute(SecurityAction.PermitOnly, PathDiscovery = "C:\\")]

    public partial class MainForm : Form
    {
        private Copier m_copier;
        private Thread m_copierThread;
        private FolderBrowserDialog m_folderbrowser;

        public MainForm()
        {
            InitializeComponent();
            m_copier = new Copier();
            m_copierThread = new Thread(this.m_copier.PerformCopying);
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
            lblCopyBtn.Text = "Copying...";
            m_copierThread = new Thread(this.m_copier.PerformCopying);
            SelectFolders();
            m_copierThread.Start();
            lblCopyBtn.Text = "Copy";
        }

        private void SelectFolders()
        {
            m_folderbrowser.Description = "Select Source";
            if (m_folderbrowser.ShowDialog() == DialogResult.OK)
            {
                m_copier.m_source = m_folderbrowser.SelectedPath;
            }
            m_folderbrowser.Description = "Select Destination";
            if (m_folderbrowser.ShowDialog() == DialogResult.OK)
            {
                m_copier.m_dest = m_folderbrowser.SelectedPath;
            }
        }
    }
}
