using System.Configuration;
using System.Data.Common;

namespace Repository
{
    public class DbFactory
    {
        public static DbConnection CreateConnection(string connectionName)
        {
            var settings = ConfigurationManager.ConnectionStrings[connectionName];

            var factory = DbProviderFactories.GetFactory(settings.ProviderName);

            var connection = factory.CreateConnection();

            connection.ConnectionString = settings.ConnectionString;

            return connection;
        }
    }
}
