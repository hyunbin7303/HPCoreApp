using System.Runtime.Serialization;
namespace HP_StockDataCollector.Domain
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
