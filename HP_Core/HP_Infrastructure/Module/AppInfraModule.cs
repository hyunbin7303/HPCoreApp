using Autofac;
using HP_Core;
namespace HP_Infrastructure.Module
{
    public class AppInfraModule : Autofac.Module
    {
        public bool isAppInfraStart { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<AppInfra>().As<IAppInfra>();
            
            if(isAppInfraStart)
            {
                
            }
            else
            {

            }
            builder.Register(a => new AppInfra()).As<IAppInfra>();
            //base.Load(builder);
        }
    }
}
