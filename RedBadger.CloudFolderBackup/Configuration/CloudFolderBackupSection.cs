namespace RedBadger.CloudFolderBackup.Configuration
{
    using System.Configuration;

    public class CloudFolderBackupSection : ConfigurationSection
    {
        [ConfigurationProperty("credentials")]
        public CredentialsElement Credentials
        {
            get
            {
                return (CredentialsElement)this["credentials"];
            }

            set
            {
                this["credentials"] = value;
            }
        }
    }
}