using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace HP_StockDataCollector.Dynamic
{
    // Part of DLR(Dynamic Language Runtime).
    // Enables you to add and delete members of its instances at run time and also to set and get values of these members.

    class Conter
    {
        // HOw this event is used?
        public event EventHandler ThresholdReached;
        protected virtual void OnThreshholdReached(EventArgs e)
        {
            EventHandler handler = ThresholdReached;
            handler?.Invoke(this, e);
        }
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

        public ExpandoObject CreateDynamicCustomer(string name)
        {
            dynamic cus = new ExpandoObject();
            cus.FullName = name;
            cus.ChangeName = (Action<string>)((string newName) =>
            {
                cus.FullName = newName;
            });
            return cus;
        }
        public ExpandoObject CreateDynamicCustomer(string propertyName, string PropertyValue)
        {
            dynamic cust = new ExpandoObject();
            ((IDictionary<string, object>)cust)[propertyName] = PropertyValue;
            return cust;
        }



        private static Task<decimal> LongRunningCancellableOperation(int loop, CancellationToken cancellationToken)
        {
            Task<decimal> task = null;

            // Start a task and return it
            task = Task.Run(() =>
            {
                decimal result = 0;

                // Loop for a defined number of iterations
                for (int i = 0; i < loop; i++)
                {
                    // Check if a cancellation is requested, if yes,
                    // throw a TaskCanceledException.
                    if (cancellationToken.IsCancellationRequested)
                        throw new TaskCanceledException(task);
                    // Do something that takes times like a Thread.Sleep in .NET Core 2.
                    Thread.Sleep(10);
                    result += i;
                }

                return result;
            });

            return task;
        }
    }
}


// https://visualstudiomagazine.com/articles/2019/04/01/making-it-up-as-you-go.aspx
// https://visualstudiomagazine.com/articles/2019/04/01/working-with-dynamic-objects.aspx
// https://www.oreilly.com/content/building-c-objects-dynamically/

