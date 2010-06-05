namespace RedBadger.CloudFolderBackup
{
    public interface IUploader
    {
        void Run(string containerName);
    }
}