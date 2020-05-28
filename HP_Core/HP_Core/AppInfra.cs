using System;


namespace HP_Core
{

    public class AppInfra : IAppInfra
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Usage { get; set; }

        public bool isAppInfraStart { get; set; }
        public bool ChangeAppStatus(bool isStart)
        {
            return isStart;
        }
        public bool ChangeName(string newName)
        {
            Name = newName;
            // TODO : validation required
            return true;
        }
        public bool ChangeUsage(string newUsage)
        {
            Usage = newUsage;
            // TODO : Validation Required
            return true;
        }
        public void Print(AppInfra outInfra)
        {
            Console.WriteLine($"Id Value : {outInfra.Id}, Name : {outInfra.Name}, Usage : {outInfra.Usage}");
        }
    }
}
