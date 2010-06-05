namespace RedBadger.CloudFolderBackup.Configuration
{
    using System.Configuration;

    public class CredentialsElement : ConfigurationElement
    {
        private const string UsernameAttributeName = "username";

        private const string ApiKeyAttributeName = "apiKey";

        [ConfigurationProperty(UsernameAttributeName, IsRequired = true, DefaultValue = CloudFolderBackupSection.IgnoredDefaultValue)]
        [StringValidator(MinLength = 1)]
        public string Username
        {
            get
            {
                return (string)this[UsernameAttributeName];
            }

            set
            {
                this[UsernameAttributeName] = value;
            }
        }

        [ConfigurationProperty(ApiKeyAttributeName, IsRequired = true, DefaultValue = CloudFolderBackupSection.IgnoredDefaultValue)]
        [StringValidator(MinLength = 1)]
        public string ApiKey
        {
            get
            {
                return (string)this[ApiKeyAttributeName];
            }

            set
            {
                this[ApiKeyAttributeName] = value;
            }
        }
    }
}