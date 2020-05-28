using Autofac;
using HP_Core;
using HP_Core.Models;
using HP_Core.Notification;
using HP_Infrastructure.Module;
using System;

namespace HP_Infrastructure
{
    public interface ITest
    {
        void Print(Test oTest);
    }
    class Program
    {
        static void Main(string[] args)
        {
            AppInfra appInfra = new AppInfra()
            {
                Id = 1,
                Name = "MyTask",
                Usage = "Management service for my task."
            };
             var container = BuildContainer();
            var myappRepo = container.Resolve<IAppInfra>();
            myappRepo.Print(appInfra);

            var test = container.Resolve<ITest>();
            var notificationService = container.Resolve<INotificationService>();
        }

        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AppInfraModule>();
            builder.RegisterModule<TestModule>();
            builder.RegisterModule<ProgramModule>();
            builder.RegisterModule<NotificationModule>();
            return builder.Build();
        }
    }
}






// Things to remember

    // Register ONce, Resolve Many? Best Practice
    // Don't register components during units of works if you can't avoid it.

    // Use nested lifetime scopes and appropriate instance scopes to keep per- uunit of-work instance separate. 