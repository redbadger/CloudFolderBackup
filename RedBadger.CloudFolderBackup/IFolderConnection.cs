namespace RedBadger.CloudFolderBackup
{
    public interface IFolderConnection
    {
        string Path { get; }

        string ZipName { get; }

        bool IsValid();
    }
}