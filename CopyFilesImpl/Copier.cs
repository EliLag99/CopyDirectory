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

        public int m_elementsCopied;
        public int m_elementsCount;

        public string m_source;
        public string m_dest;

        public string m_currSourceDir;
        public string m_currDestinDir;
        public string m_currFile;

        public Copier() 
        {
            m_currSourceDir = "";
            m_currDestinDir = "";
            m_currFile = "";
        }

        public void PerformCopying() 
        {
            m_elementsCopied = 0;
            m_elementsCount = Directory.GetFiles(m_source, "*.*", SearchOption.AllDirectories).Count();
            CopyFilesRecursively(new DirectoryInfo(m_source), new DirectoryInfo(m_dest));
        }

        private void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo destin)
        {
            m_currSourceDir = source.FullName;
            m_currDestinDir = destin.FullName;
            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                if (m_AbortCopying) return;
                CopyFilesRecursively(dir, destin.CreateSubdirectory(dir.Name));
            }
            foreach (FileInfo file in source.GetFiles())
            {
                if (m_AbortCopying) return;
                m_currFile = file.Name;
                file.CopyTo(Path.Combine(destin.FullName, file.Name));
                m_elementsCopied++;
            }
        }
    }
}
