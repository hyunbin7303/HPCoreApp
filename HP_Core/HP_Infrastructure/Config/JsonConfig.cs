using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Infrastructure.Config
{

    //Json Configuration
    // Josn file-based configuration support.
    // Upgrade : https://autofaccn.readthedocs.io/en/latest/configuration/xml.html#id4


    // Default Assembly
   

        // Components
        // Components are added to a top -level components element in configuration. 
        // Inside that is an array of the components you want to register.
        // 

        // multiple configurations than C# code.

    public class JsonConfigManager
    {

        public JsonConfigManager()
        {



            //var config = new ConfigurationBuilder();
            //config.AddJsonFile("autofac.json");
            //var module = new ConfigurationModule(config.Build());
            //var builder = new ContainerBuilder();
            //builder.RegisterModule(module);



        }

        public void SetupDefaultAssembly()
        {

        }
    }
}
