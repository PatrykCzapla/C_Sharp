using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab08_a
{
    public interface IMyList<T>
    {
        int Size { get; }
        void Add(T a);
        T Get(int index);
        T RemoveLast();
    }
    public abstract class GenericList<T>: IMyList<T>, IEnumerable<T>// dodać odpowiednie interfejsy
    {
        protected Node head;

        public int Size {
            get
            {
                int i = 0;
                Node p = head;
                while(p!=null)
                {
                    i++;
                    p = p.Next;
                }
                return i;
            }
        }

        public abstract void Add(T a);

        public T Get(int index)
        {
            if (Size == 0) throw new Exception("List is empty!");
            Node p = head;
            for(int i=0;i<index;i++)
            {
                p = p.Next;
            }
            return p.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node p = head;
            while (p != null)
            {
                yield return p.Data;
                p = p.Next;
            }
        }

        public T RemoveLast()
        {
            if (Size == 0) throw new Exception("List is empty!");
            Node p = head;
            Node prev = null;
            while (p.Next != null)
            {
                prev = p;
                p = p.Next;
            }
            T wynik = p.Data;
            if (prev == null)
            {
                head = null;
                return wynik;
            }
            prev.Next = null;
            return wynik;
        }

        public override string ToString()
        {
            string result = "";
            Node p = head;
            while (p != null)
            {
                result +="-->"+ p.Data.ToString();
                p = p.Next;
            }
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        protected class Node
        {
            public Node(T t)
            {
                Next = null;
                Data = t;
            }
            public Node Next { get; set; }
            public T Data { get; set; }
        }

    }
    public class MyList<T> : GenericList<T>
    {
        public override void Add(T a)
        {
            Node p = new GenericList<T>.Node(a);
            p.Next = head;
            head = p;
        }

    }

    public class SortedMyList<T> : GenericList<T>
        where T: IComparable<T>
    {
        public override void Add(T a)
        {
            if(head==null)
            {
                head = new GenericList<T>.Node(a);
                return;
            }
            Node p = head;
            if(p.Data.CompareTo(a)>=0)
            {
                p = new GenericList<T>.Node(a);
                p.Next = head;
                head = p;
                return;
            }
            if(p.Next==null)
            {
                head.Next = new GenericList<T>.Node(a);
                return;
            }
            while(p.Next!=null)
            {
                if (p.Next.Data.CompareTo(a)>=0)
                {
                    Node w = new GenericList<T>.Node(a);
                    w.Next = p.Next;
                    p.Next = w;
                    return;
                }
                p = p.Next;
            }
            p.Next = new GenericList<T>.Node(a);
        }

    }

    public class Person: IComparable<Person>

    {
        public int Age { get; set; }
        public string Name { get; set; }

        public int CompareTo(Person other)
        {
            int i = Name.CompareTo(other.Name);
            if (i != 0) return i;
            return Age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            return Name + ", " + Age.ToString();
        }

    }

}
