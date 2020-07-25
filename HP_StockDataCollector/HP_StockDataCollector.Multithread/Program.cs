using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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


        public void testing()
        {

        }

        internal static IEnumerable<string> Duplicates(this IEnumerable<string> items)
        {
            var hashset = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            return items.Where(i => !hashset.Add(i));
        }
    }

    internal static class HelperChecker
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


        private static readonly TimeZoneInfo TzEst = TimeZoneInfo.GetSystemTimeZones().Single(tz => tz.Id == "Estern Standard Time")
    }
}
