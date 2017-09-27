using System;
using System.Data.SqlClient;
using System.IO;


namespace Util.Datas.Tests.SqlServer.Configs {
    public static class CiConfig {
        private const string DatabaseVariable = "SqlServer_DatabaseName";
        private const string ConnectionStringTemplateVariable = "SqlServer_ConnectionStringTemplate";

        private const string MasterDatabaseName = "master";
        private const string DefaultDatabaseName = @"UtilTest";

        private const string DefaultConnectionStringTemplate =
            @"Server=.\\sql2014;Initial Catalog={0};User Id=sa;Password=sa;MultipleActiveResultSets=True";

        public static string GetDatabaseName() {
            return Environment.GetEnvironmentVariable( DatabaseVariable ) ?? DefaultDatabaseName;
        }

        public static string GetMasterConnectionString() {
            return string.Format( GetConnectionStringTemplate(), MasterDatabaseName );
        }

        public static string GetConnectionString() {
            return string.Format( GetConnectionStringTemplate(), GetDatabaseName() );
        }

        private static string GetConnectionStringTemplate() {
            return
                Environment.GetEnvironmentVariable( ConnectionStringTemplateVariable ) ??
                DefaultConnectionStringTemplate;
        }

        public static SqlConnection CreateConnection( string connectionString = null ) {
            connectionString = connectionString ?? GetConnectionString();
            var connection = new SqlConnection( connectionString );
            connection.Open();
            return connection;
        }

        public static string GetScript() {
            var scriptPath = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "database.sql" );
            return File.ReadAllText( scriptPath );
        }
    }
}