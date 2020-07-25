using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HP_Infrastructure.Database
{
    public class DBHelper
    {
        public ProviderManager ProviderManager { get; set; }
        public string ConnectionString { get; set; }
        public DBHelper()
        {
            ConnectionString = ConfigurationSetting.ConnectionString;
            ProviderManager = new ProviderManager();
        }
        public DBHelper(string connName)
        {
            ConnectionString = ConfigurationSetting.GetConnectionString(connName);
            ProviderManager = new ProviderManager(ConfigurationSetting.GetProviderName(connName));
        }
        public IDbConnection GetConnection()
        {
            try
            {
                var conn = ProviderManager.Factory.CreateConnection();
                conn.ConnectionString = ConnectionString;
                conn.Open();
                return conn;
            }catch(Exception)
            {
                return null;
            }
        }

    }
}
