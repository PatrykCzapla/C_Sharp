using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11b
{
    interface IWatcher
    {
        void Watch(IObservableCollection icn);
        void StopWatching(IObservableCollection icn);
    }

    class SimpleWatcher : IWatcher
    {
        EventHandler<CollectionCahngedEventArgs> func = (object sender, CollectionCahngedEventArgs e) =>
        {
            Console.WriteLine("Collection changed");
        };

        public void StopWatching(IObservableCollection icn)
        {
            icn.CollectionCahnged -= func;
        }

        public void Watch(IObservableCollection icn)
        {
            icn.CollectionCahnged += func;
        }
    }
    class SmartWatcher : IWatcher
    {
        EventHandler<CollectionCahngedEventArgs> func = (object sender, CollectionCahngedEventArgs e) =>
        {
            Console.WriteLine("Collection: "+ (sender as ObservableCollection).Name + " changed, value: " +  e.Value + " was " + e.Operation+"ed");
        };

        public void StopWatching(IObservableCollection icn)
        {
            icn.CollectionCahnged -= func;
        }

        public void Watch(IObservableCollection icn)
        {
            icn.CollectionCahnged += func;
        }
    }
}
