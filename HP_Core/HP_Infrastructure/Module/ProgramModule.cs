using Autofac;
using Autofac.Configuration;
using HP_Core.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace HP_Infrastructure.Module
{
    //Advantages of using modules
    // Decresed config complexity
    // good for dynamic Configuration
    //Advanced Extensions???
    // -- Attach to component resolution events and extend how parameters are resolved or perform other extensions. (e.g. log4net integration module).
    public class ProgramModule : Autofac.Module
    {
        private DeployType deploytype;
        public DeployType DeployType
        {
            get { return deploytype; }
            set
            {
                if (value == DeployType.Development)
                {
                    deploytype = DeployType.Development;
                }
                deploytype = DeployType.Development;
            }
        }

        private readonly string configPath;
        protected override void Load(ContainerBuilder builder)
        {
            var buildconfig = new ConfigurationBuilder()
            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
                    IConfiguration config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();

            if (deploytype == DeployType.Development)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }
            //RegisterCommonDependencies(builder);
            base.Load(builder);
        }
        private void deployTypeChecker(DeployType type)
        {
            switch (type)
            {
                case DeployType.Development:
                    System.Console.WriteLine("DEVELOPMENT TYPE DEPLOYMENT");
                    break;


                case DeployType.Production:
                    System.Console.WriteLine("PRODUCTION TYPE DEPLOYMENT");
                    break;

                default:
                    break;
            }

        }

        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
        }
        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
        }

    }
}
