namespace RedBadger.CloudFolderBackup
{
    public interface IFolderConnection
    {
        string Path { get; }

        bool IsValid();
    }
}