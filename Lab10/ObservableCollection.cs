using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11b
{
    class ObservableCollection : IObservableCollection
    {
        List<object> lista = new List<object>();
        public string Name
        {
            get;
        }
        public ObservableCollection(string Name)
        {
            this.Name = Name;
        }

        public event EventHandler<CollectionCahngedEventArgs> CollectionCahnged = null;
        void fun2 (object sender, CollectionCahngedEventArgs arg)
        {
           
        }
        public void Add(object value)
        {
                    
            if(value.GetType()==(Type)typeof(NotifingObject))
            {
                
            }
            if (value != null)
            {
                lista.Add(value);
                if(value is NotifingObject)    
                if (CollectionCahnged != null) CollectionCahnged.Invoke(this, new CollectionCahngedEventArgs(CollectionOperation.Add, value));

            }
        }

        public void Remove(object value)
        { 
            if (value != null && lista != null)
            {
                lista.Remove(value);
                if (CollectionCahnged != null) CollectionCahnged.Invoke(this, new CollectionCahngedEventArgs(CollectionOperation.Remove, value));
            }
                
        }

        
    }
    public class NotifingObject : IChangeNotifing
    {
        public event EventHandler NameChanged;
        private string name;
        public string Name
        {
            get { return name; }
            set
            {

                name = Name;
                NameChanged.Invoke(this, new CollectionCahngedEventArgs(CollectionOperation.ValueChanged, this));
            }
        }
      
        public override string ToString()
        {
            return Name;
        }
    }
}
