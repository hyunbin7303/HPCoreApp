// TODO : For now, I'm use this file for testing purpose.

namespace HP_Infrastructure
{
    public class Test : ITest
    {
        public int testId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public void Print(Test oTest)
        {
            System.Console.WriteLine($"testId : {testId}, Name : {Name}");
        }
    }
}
