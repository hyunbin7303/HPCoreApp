using System;
using System.Threading;
using System.Threading.Tasks;

namespace HP_StockDataCollector.Multithread
{
    class Program
    {
        static void Main(string[] args)
        {
            Semaphore semaphoreObj = new Semaphore(initialCount: 3, maximumCount: 3);
            Printer printObj = new Printer();
            // init Count
            // Maximum Count 
            for (int i = 0; i < 20; ++i)
            {
                int j = i;
                Task.Factory.StartNew(() =>
                {
                    semaphoreObj.WaitOne();
                    printObj.Print(j);
                    semaphoreObj.Release();
                });
            }
            Console.ReadLine();
        }
    }
    // Semaphore testing
    // C# semaphore allows only a limited number of threads to enter into a critical section.
    // Mainly used in scenarios where we have limited number of resources and we have to limit the number of threads
    // that can use it. 
    class Printer
    {
        public void Print(int documentToPrint)
        {
            Console.WriteLine("Printing document: " + documentToPrint);
            //code to print document
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }
    }
}
