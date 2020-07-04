using System;
using System.Collections.Generic;
using System.Text;

namespace HP_StockDataCollector.Domain
{
    public class HistoricalData
    {
        //Epoch & Unix Timestamp Conversion required.
        public DateTime date { get; set; } // Epoch TIme???
            
    
        public DateTime UnitTimeToDateTime(string unixtimeStr)
        {
            long unixTime = Convert.ToInt64(unixtimeStr);
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dateTime = dateTime.AddMilliseconds(unixTime).ToLocalTime();
            return dateTime;
        }
    }
}
