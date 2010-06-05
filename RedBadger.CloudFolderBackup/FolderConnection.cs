namespace RedBadger.CloudFolderBackup
{
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

        public bool IsValid()
        {
            return Directory.Exists(this.Path);
        }
    }
}