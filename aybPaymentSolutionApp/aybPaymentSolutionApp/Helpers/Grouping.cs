using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace aybPaymentSolutionApp.Helpers
{
    public class Grouping<K, T> : ObservableCollection<T>
    {

        public K keyGrouping { get; }
        public Grouping(K key, IEnumerable<T> items)
        {
            keyGrouping = key;
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

    }
}
