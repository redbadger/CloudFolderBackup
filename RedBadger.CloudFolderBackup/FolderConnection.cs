namespace RedBadger.CloudFolderBackup
{
    using System;
    using System.IO;

    public class FolderConnection : IFolderConnection
    {
        public FolderConnection(string path)
        {
            this.Path = path;
        }

        public string Path
        {
            get; private set;
        }

        public string ZipName
        {
            get
            {
                return string.Format("{0}.zip", new DirectoryInfo(this.Path).Name);
            }
        }

        public bool IsValid()
        {
            return Directory.Exists(this.Path);
        }
    }
}