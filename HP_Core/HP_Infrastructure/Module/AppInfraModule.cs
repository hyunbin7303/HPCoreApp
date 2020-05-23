using Autofac;

namespace HP_Infrastructure.Module
{
    public class AppInfraModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppInfra>().As<IAppInfra>();
            base.Load(builder);
        }
    }
}
