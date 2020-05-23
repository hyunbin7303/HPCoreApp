using Autofac;
using HP_Infrastructure.Module;
using System;


// TODO : For now, I'm use this file for testing purpose.

namespace HP_Infrastructure
{
    public interface ITest
    {
        void Print(Test oTest);
    }
    public interface IAppInfra
    {
        void Print(AppInfra outInfra);
    }
    public class AppInfra : IAppInfra
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Usage { get; set; }
        public void Print(AppInfra outInfra)
        {
            Console.WriteLine($"Id Value : {outInfra.Id}, Name : {outInfra.Name}, Usage : {outInfra.Usage}");
        }
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
        }

        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AppInfraModule>();
            builder.RegisterModule<TestModule>();
            return builder.Build();
        }
    }
}
