using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace HP_Infrastructure.Database
{
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
