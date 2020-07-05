using System;
using System.Collections.Generic;
using System.Text;

namespace HP_StockDataCollector.Domain
{

    // Investopedia
    // A candlestick is a type of price chart used in technical analysis that displays the high, low, open, and
    // closing prices of a security for a specific period.
    //Candlesticks reflect the impact of investor sentiment on security prices and used by technical analysts to determine when to enter and exit trades. 
    public class CandleData
    {
        private DateTime date;
        public DateTime GetDate()
        {
            return date;
        }
        public void SetDate(long value)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(value).ToLocalTime();
            date = dtDateTime;
        }

        public decimal Open { get; set; }
        public decimal High { get; set; }

        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }
        public decimal Adjclose { get; set; }
    }
}
