namespace RedBadger.CloudFolderBackup
{
    using System.IO;

    using Ionic.Zip;

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

        public bool IsValid()
        {
            return Directory.Exists(this.Path);
        }
    }
}