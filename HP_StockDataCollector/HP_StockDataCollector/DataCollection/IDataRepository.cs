using HP_StockDataCollector.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_StockDataCollector.DataCollection
{
    public interface IDataRepository
    {
        IEnumerable<object> GetAll();
        QuoteData Get(int id);
        void Create(QuoteData quote);
        void Update(int id, QuoteData quote);
        void Delete(QuoteData quote);
    }
}
