using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Dynamic;

namespace HP_StockDataCollector.Dynamic
{
    class Conter
    {


        // HOw this event is used?
        public event EventHandler ThresholdReached;
        protected virtual void OnThreshholdReached(EventArgs e)
        {
            EventHandler handler = ThresholdReached;
            handler?.Invoke(this, e);
        }


        // Delegates....
        // A delegate is a type that holds a reference to a method.

    
    }



    public class DynamicCollectionCheck
    {
        public void Checking()
        {
            // Expando object to create an initial object to hold the properties.
            dynamic expando = new ExpandoObject();
            expando.Name = "Kevin";
            expando.HAHA = "WTF";
            AddProperty(expando, "Name", "aaa");
            expando.IsValid = (Func<bool>)(() =>
            {
                if(string.IsNullOrWhiteSpace(expando.Name))
                {
                    return false;
                }
                return true;
            });


            if(!expando.IsValid())
            {
                // not valid, so get out.
            }

        }

        public static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            // ExpandoObject supports IDictionary so we can extend it like this
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }



        // Part of DLR(Dynamic Language Runtime).
        // Enables you to add and delete members of its instances at run time and also to set and get values of these members.

    }
}
