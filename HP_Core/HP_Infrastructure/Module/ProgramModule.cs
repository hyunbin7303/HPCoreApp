using Autofac;
using HP_Core.Enums;
using System;
using System.Collections.Generic;
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
        protected override void Load(ContainerBuilder builder)
        {
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
