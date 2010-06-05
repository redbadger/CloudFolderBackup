namespace RedBadger.CloudFolderBackup
{
    using System.Configuration;

    using com.mosso.cloudfiles;
    using com.mosso.cloudfiles.domain;

    using RedBadger.CloudFolderBackup.Configuration;

    public static class Agent
    {
        public static void Run()
        {
            var config = (CloudFolderBackupSection)ConfigurationManager.GetSection("cloudFolderBackupGroup/cloudFolderBackup");

            var uploader = new Uploader(
                new FolderConnection(config.Operation.SourceFolderPath),
                new Connection(new UserCredentials(config.Credentials.Username, config.Credentials.ApiKey)));

            uploader.Run(config.Operation.DestinationContainer);
        }
    }
}