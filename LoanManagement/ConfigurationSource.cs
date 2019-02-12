using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using System.Configuration;

namespace LoanManagement
{
    internal static class ConfigurationSource
    {
        public static DictionaryConfigurationSource GenerateConfiguration()
        {
            DictionaryConfigurationSource source = new DictionaryConfigurationSource();
            source.Add(DatabaseSettings.SectionName, GenerateDatabaseSettings());
            source.Add("connectionStrings", GenerateConnectionStringSection());
            return source;
        }

        private static DatabaseSettings GenerateDatabaseSettings()
        {
            DatabaseSettings settings = new DatabaseSettings
            {
                DefaultDatabase = "LoanManagement"
            };
            settings.ProviderMappings.Add(new DbProviderMapping());
            return settings;
        }

        private static ConnectionStringsSection GenerateConnectionStringSection()
        {
            ConnectionStringsSection section = new ConnectionStringsSection();
            section.ConnectionStrings.Add(new ConnectionStringSettings("LoanManagement",
                ConfigurationManager.ConnectionStrings["LoanManagement"].ConnectionString, "MySql.Data.MySqlClient"));
            return section;
        }

    }
}