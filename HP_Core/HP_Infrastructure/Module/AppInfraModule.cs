using Autofac;
using HP_Core;
using HP_Core.Enums;

namespace HP_Infrastructure.Module
{
    public class AppInfraModule : Autofac.Module
    {
        public bool isAppInfraStart { get; set; }
        public AppInfra appInfra { get; set; }


        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(a => new AppInfra()).As<IAppInfra>();

            // TODO : Logging infra is required.
            // builder.Register(l => new LoggingInfra()).As<ILog>();

            if (isAppInfraStart)
            {
                // Builder register for Redis
                // Builder register for Azure Service
                // Builder Register for other components.
              
            
            }
            else
            {
                // Application Infra doesn't start.
            }
        }

    }
}





// Exampl