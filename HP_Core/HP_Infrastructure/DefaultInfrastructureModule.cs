using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Module = Autofac.Module;



// Got some codes from CleanArchitecture project.
//Reference
//Source : https://github.com/ardalis/CleanArchitecture
namespace HP_Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private bool _isDevelopment = false;
        private List<Assembly> _assemblies = new List<Assembly>();


        protected override void Load(ContainerBuilder builder)
        {
            if (_isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }
            //RegisterCommonDependencies(builder);
        }




        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
        }
        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
        }
    }
}
