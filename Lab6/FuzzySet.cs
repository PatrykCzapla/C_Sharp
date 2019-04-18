using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class FuzzySet
    {
        public Dictionary<int, float> set;

        public FuzzySet(params (int, float)[] set)
        {
            this.set = new Dictionary<int, float>();

            foreach ((int val,float prob) elem in set)
            {
                if(this.set.ContainsKey(elem.val)) continue;
                this.set.Add(elem.val, elem.prob);
            }
        }

        public override string ToString()
        {
            string result = "{";           

            foreach(KeyValuePair<int,float> elem in set)
            {
                result = result + "(" + elem.Key + "," + elem.Value + ")";
            }
               
            result = result + "}";
            return result;
        }
        
        public static FuzzySet operator+(FuzzySet a, (int,float) b)
        {
            FuzzySet A = new FuzzySet();
            foreach (KeyValuePair<int, float> elem in a.set)
            {
                A.set.Add(elem.Key, elem.Value);
            }
            if (A.set.ContainsKey(b.Item1))
            {
                if (A.set[b.Item1] >= b.Item2) return A;
                A.set.Remove(b.Item1);
                A.set.Add(b.Item1, b.Item2);
                return A;
            }
            A.set.Add(b.Item1, b.Item2);
            return A;
        }

        public static FuzzySet operator +(FuzzySet a, FuzzySet b)
        {
            FuzzySet A = new FuzzySet();
            foreach (KeyValuePair<int, float> elem in a.set)
            {
                if(b.set.ContainsKey(elem.Key))
                {
                    A.set.Add(elem.Key, (elem.Value >= b.set[elem.Key] ? elem.Value : b.set[elem.Key]));
                    break;
                }
                A.set.Add(elem.Key, elem.Value);
            }
            foreach (KeyValuePair<int, float> elem in b.set)
            {
                if (!(A.set.ContainsKey(elem.Key)))
                {
                    A.set.Add(elem.Key, elem.Value);
                }
            }
            return A;
        }
        public static FuzzySet operator /(FuzzySet a, FuzzySet b)
        {
            FuzzySet A = new FuzzySet();
            foreach (KeyValuePair<int, float> elem in a.set)
            {
                if (!(b.set.ContainsKey(elem.Key)))
                {
                    A.set.Add(elem.Key, elem.Value);

                }
                else
                {
                    if ((elem.Value - b.set[elem.Key]) > 0)
                    {
                        A.set.Add(elem.Key,( elem.Value - b.set[elem.Key]));
                    }
                }
                
            }
            
            return A;
        }

        public static FuzzySet operator -(FuzzySet a)
        {
            FuzzySet A = new FuzzySet();
            foreach (KeyValuePair<int, float> elem in a.set)
            {
                A.set.Add(elem.Key, (1-elem.Value));
            }
            return A;

        }
        public static bool operator ==(FuzzySet a, FuzzySet b)
        {
            if (a.set.Count != b.set.Count) return false;
            foreach (KeyValuePair<int, float> elem in a.set)
            {
                if (!(b.set.ContainsKey(elem.Key))) return false;
                if (elem.Value != b.set[elem.Key]) return false;
                
            }
            
            return true;
        }
        public static bool operator !=(FuzzySet a, FuzzySet b)
        {
            return (!(a == b));
        }

        public static bool operator <(FuzzySet a, FuzzySet b)
        {
            foreach (KeyValuePair<int, float> elem in a.set)
            {
                if (!(b.set.ContainsKey(elem.Key))||b.set[elem.Key]<=elem.Value) return false;
                

            }
            return true;
        }
        public static bool operator >(FuzzySet a, FuzzySet b)
        {
            foreach (KeyValuePair<int, float> elem in b.set)
            {
                if (!(a.set.ContainsKey(elem.Key)) || a.set[elem.Key] <= elem.Value) return false;


            }
            return true;
        }
        public override bool Equals(object obj)
        {
            return this == (FuzzySet)obj;
        }
        public override int GetHashCode()
        {
            return set.GetHashCode();
        }
    }
}
