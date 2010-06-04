namespace RedBadger.CloudFolderBackup
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using com.mosso.cloudfiles;

    using RedBadger.CloudFolderBackup.Extensions;

    public class Runner : IRunner
    {
        private readonly IFolderConnection folderConnection;

        private readonly IConnection cloudConnection;

        public Runner(IFolderConnection folderConnection, IConnection cloudConnection)
        {
            this.folderConnection = folderConnection;
            this.cloudConnection = cloudConnection;
        }

        public void Run(string containerName)
        {
            if (!this.folderConnection.IsValid())
            {
                throw new DirectoryNotFoundException(string.Format("Unable to access {0}", this.folderConnection.Path));
            }

            List<string> containers = this.cloudConnection.GetContainers();

            if (containers.IsNullOrEmpty() || !containers.Contains(containerName))
            {
                throw new IndexOutOfRangeException(string.Format("Could not find Container: {0}", containerName));
            }
        }
    }
}