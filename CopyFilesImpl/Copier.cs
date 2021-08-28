using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CopyFilesImpl
{
    //Class which stores source and dest paths, copies from source to dest
    public class Copier
    {
        private bool f_abortCopying;
        private bool f_copying;
        public bool F_abortCopying { get => f_abortCopying; set => f_abortCopying = value; }
        public bool F_copying{ get => f_copying; }

        private int m_elementsCopied;
        private int m_elementsCount;
        public int M_elementsCopied { get => m_elementsCopied; }
        public int M_elementsCount { get => m_elementsCount; }

        private string m_source;
        private string m_dest;
        public string M_source { get => m_source; }
        public string M_dest { get => m_dest; }

        private string m_currSourceDir;
        private string m_currDestinDir;
        private string m_currFile;
        public string M_currSourceDir { get => m_currSourceDir; }
        public string M_currDestinDir { get => m_currDestinDir; }
        public string M_currFile { get => m_currFile; }

        public Copier() 
        {

        }

        public void PerformCopying(string src, string dst, bool overwrite = true) 
        {
            m_elementsCopied = 0;
            m_source = src;
            m_dest = dst;
            m_elementsCount = Directory.GetFiles(m_source, "*.*", SearchOption.AllDirectories).Count();
            CopyFilesRecursively(new DirectoryInfo(m_source), new DirectoryInfo(m_dest), overwrite);
        }

        private void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo destin, bool overwrite)
        {
            f_copying = true;
            m_currSourceDir = source.FullName;
            m_currDestinDir = destin.FullName;

            if (m_currSourceDir == m_currDestinDir) return;
            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                if (f_abortCopying) return;
                CopyFilesRecursively(dir, destin.CreateSubdirectory(dir.Name), overwrite);
            }
            foreach (FileInfo file in source.GetFiles())
            {
                if (f_abortCopying) return;

                m_currFile = file.Name;
                if(overwrite || !File.Exists(Path.Combine(destin.FullName, file.Name)))
                    file.CopyTo(Path.Combine(destin.FullName, file.Name), true);

                m_elementsCopied++;
            }
            f_copying = false;
        }
    }
}
