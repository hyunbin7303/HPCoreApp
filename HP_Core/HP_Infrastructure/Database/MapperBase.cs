using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace HP_Infrastructure.Database
{
    public abstract class MapperBase<T>
    {
        protected abstract T Map(IDataRecord dataRecord);
        public Collection<T> MapAll(IDataReader reader)
        {
            Collection<T> collection = new Collection<T>();
            while(reader.Read())
            {
                try
                {
                    collection.Add(Map(reader));
                }
                catch
                {
                    throw;
                }
            }
            return collection;
        }
    }
}
