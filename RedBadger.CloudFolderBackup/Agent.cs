namespace RedBadger.CloudFolderBackup
{
    using System;
    using System.Configuration;

    using com.mosso.cloudfiles;
    using com.mosso.cloudfiles.domain;

    using log4net;

    using RedBadger.CloudFolderBackup.Configuration;

    public static class Agent
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Agent));

        public static void Run()
        {
            log4net.Config.XmlConfigurator.Configure();

            try
            {
                var config = (CloudFolderBackupSection)ConfigurationManager.GetSection("cloudFolderBackupGroup/cloudFolderBackup");

                var uploader = new Uploader(
                    new FolderConnection(config.Operation.SourceFolderPath),
                    new Connection(new UserCredentials(config.Credentials.Username, config.Credentials.ApiKey)));

                uploader.Run(config.Operation.DestinationContainer);
                Log.Info("Success");
            }
            catch (Exception exception)
            {
                Log.Fatal(exception.Message, exception);
                throw;
            }
        }
    }
}