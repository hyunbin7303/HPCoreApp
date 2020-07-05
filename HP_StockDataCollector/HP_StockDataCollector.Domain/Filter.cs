using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HP_StockDataCollector.Domain
{
    public enum Filter
    {
        [EnumMember(Value = "history")]
        HistoricalPrices,

        [EnumMember(Value = "div")]
        DividendsOnly,

        [EnumMember(Value = "split")]
        StockSplits
    }
}
