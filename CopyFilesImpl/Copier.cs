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
        public bool m_AbortCopying;
        public bool f_copying;

        public int m_elementsCopied;
        public int m_elementsCount;

        public string m_source;
        public string m_dest;

        public string m_currSourceDir;
        public string m_currDestinDir;
        public string m_currFile;

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
            m_currSourceDir = source.FullName;
            m_currDestinDir = destin.FullName;
            if (m_currSourceDir == m_currDestinDir) return;
            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                if (m_AbortCopying) return;
                CopyFilesRecursively(dir, destin.CreateSubdirectory(dir.Name), overwrite);
            }
            foreach (FileInfo file in source.GetFiles())
            {
                if (m_AbortCopying) return;

                m_currFile = file.Name;
                if(overwrite || !File.Exists(Path.Combine(destin.FullName, file.Name)))
                    file.CopyTo(Path.Combine(destin.FullName, file.Name), true);

                m_elementsCopied++;
            }
        }
    }
}
