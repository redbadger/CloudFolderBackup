﻿namespace RedBadger.CloudFolderBackup
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using com.mosso.cloudfiles;

    using Ionic.Zip;

    using RedBadger.CloudFolderBackup.Extensions;

    public class Uploader : IUploader
    {
        private readonly IConnection cloudConnection;

        private readonly IFolderConnection folderConnection;

        public Uploader(IFolderConnection folderConnection, IConnection cloudConnection)
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

            using (var stream = new MemoryStream())
            {
                using (var zipFile = new ZipFile())
                {
                    zipFile.AddDirectory(this.folderConnection.Path);
                    zipFile.Save(stream);

                    stream.Seek(0, SeekOrigin.Begin);
                    this.cloudConnection.PutStorageItem(containerName, stream, this.folderConnection.ZipName);
                }
            }
        }
    }
}