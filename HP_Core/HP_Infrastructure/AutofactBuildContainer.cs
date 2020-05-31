using Autofac;
using HP_Infrastructure.Module;

namespace HP_Infrastructure
{
    public static class AutofactBuildContainer
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AppInfraModule>();
            builder.RegisterModule<ProgramModule>();
            builder.RegisterModule<NotificationModule>();
            return builder.Build();
        }
    }
}



// Not using for now, but I would like to remember this because... who knows when I may find use case for it?
// possible to configure DI container from settings file.
//you can put configuration in external file.

