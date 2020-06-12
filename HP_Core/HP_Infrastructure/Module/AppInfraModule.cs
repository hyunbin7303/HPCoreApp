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
                //builder.Register(r => new RedisManager()).As<IRedis>();
                // Builder register for Azure Service
                //builder.Register(r => new AzureServiceManager()).As<IAzureService>();
                // Builder Register for other components.
                //builder.Register(r => new OtherComponent()).As<IComponentManager>();
            }
            else
            {
                // Application Infra doesn't start.
            }
        }

    }
}





// Exampl