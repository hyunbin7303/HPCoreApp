using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HP_StockDataCollector.YahooFinance
{
    public enum Frequency
    {
        [EnumMember(Value = "1d")]
        Daily,

        [EnumMember(Value = "1wk")]
        Weekly,

        [EnumMember(Value = "1mo")]
        Monthly
    }
    
}
