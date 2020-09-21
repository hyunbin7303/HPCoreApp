using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace HP_Infrastructure.Database
{
    internal static class ConfigurationSetting
    {
        public static string DefaultConnection
        {
            get
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
                var defaultConnStr = builder.GetSection("DefaultConnection").Value;
                return defaultConnStr;
            }
        }
        public static string ProviderName
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[DefaultConnection].ProviderName;
            }
        }
        public static string GetProviderName(string connName)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[0].ProviderName;
            }catch(Exception)
            {
                throw new Exception(string.Format($"Provider is not working,,, Connection string {0} not Found.", connName));
            }
        }
        public static string ConnectionString
        {
            get
            {
                try
                {
                    var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
                    var defaultConnStr = builder.GetSection("DefaultConnection").Value;
                    return defaultConnStr;
                }
                catch (Exception e)
                {
                    throw new Exception(string.Format($"Conn string {0} failed to find.", DefaultConnection) + e.Message);
                }

            }
        }
        public static string GetConnectionString(string connName)
        {
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString;
                }catch(Exception)
                {
                    throw new Exception(string.Format($"Connection string {0} not found.", ConnectionString));
                }
            }
        }
    }
}
