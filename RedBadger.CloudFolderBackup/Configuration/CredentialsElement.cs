namespace RedBadger.CloudFolderBackup.Configuration
{
    using System.Configuration;

    public class CredentialsElement : ConfigurationElement
    {
        /// <summary>
        /// The StringValidator first validates the DefaultValue, if this is absent a MinLength of 1 will fail.
        /// You therefore need to provide a value that will pass the StringValidator - even though in this configuration,
        /// that value will never be used.
        /// </summary>
        private const string IgnoredDefaultValue = "ignoredValue";

        [ConfigurationProperty("username", IsRequired = true, DefaultValue = IgnoredDefaultValue)]
        [StringValidator(MinLength = 1)]
        public string Username
        {
            get
            {
                return (string)this["username"];
            }

            set
            {
                this["username"] = value;
            }
        }

        [ConfigurationProperty("apiKey", IsRequired = true, DefaultValue = IgnoredDefaultValue)]
        [StringValidator(MinLength = 1)]
        public string ApiKey
        {
            get
            {
                return (string)this["apiKey"];
            }

            set
            {
                this["apiKey"] = value;
            }
        }
    }
}