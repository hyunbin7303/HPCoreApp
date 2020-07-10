using System;
using System.Collections.Generic;
using System.Text;

namespace HP_StockDataCollector.Multithread
{
    public class TestingSpan
    {
        public TestingSpan()
        {
            Console.WriteLine("TESTING SPAN");
        }
        public void TestSpanMethod1()
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            Span<int> span = arr.AsSpan();
            Span<int> slice = span.Slice(1, 3);
            foreach (var item in slice)
            {
                Console.WriteLine(item);
            }

        }
    }
}
