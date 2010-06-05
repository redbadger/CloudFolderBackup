namespace RedBadger.CloudFolderBackup.Configuration
{
    using System.Configuration;

    public class CloudFolderBackupSection : ConfigurationSection
    {
        /// <summary>
        /// The StringValidator first validates the DefaultValue, if this is absent a MinLength of 1 will fail.
        /// You therefore need to provide a value that will pass the StringValidator - even though in this configuration,
        /// that value will never be used.
        /// </summary>
        internal const string IgnoredDefaultValue = "ignoredValue";

        private const string CredentialElementName = "credentials";

        private const string OperationElementName = "operation";

        [ConfigurationProperty(CredentialElementName)]
        public CredentialsElement Credentials
        {
            get
            {
                return (CredentialsElement)this[CredentialElementName];
            }

            set
            {
                this[CredentialElementName] = value;
            }
        }

        [ConfigurationProperty(OperationElementName)]
        public OperationElement Operation
        {
            get
            {
                return (OperationElement)this[OperationElementName];
            }

            set
            {
                this[OperationElementName] = value;
            }
        }
    }
}