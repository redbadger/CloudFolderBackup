namespace RedBadger.CloudFolderBackup.Configuration
{
    using System.Configuration;

    public class OperationElement : ConfigurationElement
    {
        private const string DestinationContainerAttributeName = "destinationContainer";

        private const string SourceFolderPathAttributeName = "sourceFolderPath";

        [ConfigurationProperty(SourceFolderPathAttributeName, IsRequired = true, DefaultValue = CloudFolderBackupSection.IgnoredDefaultValue)]
        [StringValidator(MinLength = 1)]
        public string SourceFolderPath
        {
            get
            {
                return (string)this[SourceFolderPathAttributeName];
            }

            set
            {
                this[SourceFolderPathAttributeName] = value;
            }
        }

        [ConfigurationProperty(DestinationContainerAttributeName, IsRequired = true, DefaultValue = CloudFolderBackupSection.IgnoredDefaultValue)]
        [StringValidator(MinLength = 1)]
        public string DestinationContainer
        {
            get
            {
                return (string)this[DestinationContainerAttributeName];
            }

            set
            {
                this[DestinationContainerAttributeName] = value;
            }
        }
    }
}