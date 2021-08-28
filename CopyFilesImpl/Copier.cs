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
        public string m_source { get; set; }
        public string m_dest { get; set; }

        public Copier() { }

        public void PerformCopying() 
        {
            CopyFilesRecursively(new DirectoryInfo(m_source), new DirectoryInfo(m_dest));
        }

        private void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo dest)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, dest.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(dest.FullName, file.Name));
        }
    }
}
