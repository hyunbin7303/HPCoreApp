using System;
using System.Collections.Generic;
using System.Text;

namespace HP_StockDataCollector.Domain
{
    public class Summary
    {
        public double PreviousClose { get; set; }
        public double Open { get; set; }
        public double Volume { get; set; }
        public double DayRange { get; set; }
        public double WeekRange52 { get; set; }
        public double  AvgVolume { get; set; }
    }
}
