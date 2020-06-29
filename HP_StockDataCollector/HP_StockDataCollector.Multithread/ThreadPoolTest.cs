using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HP_StockDataCollector.Multithread
{


    // Thread pool is a colection of threads which can be used to perform no of task in background.
    // Once thread completes its task then it sent to the pool to a queue of waiting threads, where it can be reused.
    // This reusability avoids an application to create more threads and this enables less memory consumption.
    public class ThreadPoolTest
    {

        static void Process(object Callback)
        {

        }

        static void ProcessWithThreeMethods()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }

    }
  //  A callback is executable code that is passed as an argument to other code
    public class Parent
    {
        public string Read() { return "Parent"; }
    }
    public class Child
    {
        private string info;
        delegate string GetInfo();
        public GetInfo GetMemberInformation;
        public void ObtainInfo()
        {
            info = GetMemberInformation();
        }
    }
    


}
