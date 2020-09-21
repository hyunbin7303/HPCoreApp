using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace HP_Infrastructure.Database
{
    internal enum DataAccessProviderTypes
    {
        SqlServer,
        SqLite,
        MySql,
        PostgreSql,
#if NETFULL
    OleDb,
    SqlServerCompact
#endif
    }
    public class ProviderManager
    {

        public string ProviderName { get; set; }
        public DbProviderFactory Factory
        {
            get
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderName);
                return factory;
            }
        }
        public DbProviderFactory GetDbProviderFactory(string providerName, string v)
        {
#if NETFULL
    return DbProviderFactories.GetFactory(providerName);
#else
            var providername = providerName.ToLower();

            if (providerName == "system.data.sqlclient")
                return GetDbProviderFactory(DataAccessProviderTypes.SqlServer);
            if (providerName == "system.data.sqlite" || providerName == "microsoft.data.sqlite")
                return GetDbProviderFactory(DataAccessProviderTypes.SqLite);
            if (providerName == "mysql.data.mysqlclient" || providername == "mysql.data")
                return GetDbProviderFactory(DataAccessProviderTypes.MySql);
            if (providerName == "npgsql")
                return GetDbProviderFactory(DataAccessProviderTypes.PostgreSql);

            throw new NotSupportedException(string.Format("Unsupported Provider Factory", providerName));
#endif
        }
        public static DbProviderFactory GetDbProviderFactory(DataAccessProviderTypes type)
        {
            if (type == DataAccessProviderTypes.SqlServer)
                return SqlClientFactory.Instance; // this library has a ref to SqlClient so this works

            if (type == DataAccessProviderTypes.SqLite)
            {
#if NETFULL
        return GetDbProviderFactory("System.Data.SQLite.SQLiteFactory", "System.Data.SQLite");
#else
                return GetDbProviderFactory("Microsoft.Data.Sqlite.SqliteFactory", "Microsoft.Data.Sqlite");
#endif
            }
            if (type == DataAccessProviderTypes.MySql)
                return GetDbProviderFactory("MySql.Data.MySqlClient.MySqlClientFactory", "MySql.Data");
            if (type == DataAccessProviderTypes.PostgreSql)
                return GetDbProviderFactory("Npgsql.NpgsqlFactory", "Npgsql");
#if NETFULL
    if (type == DataAccessProviderTypes.OleDb)
        return System.Data.OleDb.OleDbFactory.Instance;
    if (type == DataAccessProviderTypes.SqlServerCompact)
        return DbProviderFactories.GetFactory("System.Data.SqlServerCe.4.0");
#endif

            throw new NotSupportedException(string.Format("Unsupported Provider Factory", type.ToString()));
        }
        public ProviderManager()
        {
            ProviderName = ConfigurationSetting.GetProviderName(ConfigurationSetting.DefaultConnection);
        }
        public ProviderManager(string providerName)
        {
            ProviderName = providerName;
        }

    
    }
}
