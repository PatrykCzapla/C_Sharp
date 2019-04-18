using System;
using System.Collections;

namespace Lab8
{
    public class Naturalne : IEnumerable
    {
        int first;
        public Naturalne (int first = 0)
        {
            this.first = first;
        }
        public IEnumerator GetEnumerator()
        {
            int i = first;
            while(true)
            {
                yield return i++;
            }
        }
    }

    public class Losowe : IEnumerable
    {
        int seed;
        int max;
        Random rand;
        public Losowe(int seed, int max)
        {
            this.seed = seed;
            this.max = max;
        }
        public IEnumerator GetEnumerator()
        {
            rand = new Random(seed);
            while(true)
            {
                yield return rand.Next(0, max);
            }
        }
    }

    public class Tetranacci : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int i=0;
            int k = 0;
            int t0 = 0;
            int t1 = 0;
            int t2 = 0;
            int t3 = 1;
            while(true)
            {
                if (i==0||i==1||i==2)
                {
                    i++;
                    yield return t0;
                    continue;
                }
                else if(i==3)
                {
                    i++;
                    yield return t3;
                    continue;
                } else
                {
                    k = t0 + t1 + t2 + t3;
                    t0 = t1;
                    t1 = t2;
                    t2 = t3;
                    t3 = k;
                    i++;
                    yield return k;
                }
                
            }

        }
    }

    public class Catalan : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int c0 = 1;
            int i = 0;
            while(true)
            {
                if(i==0)
                {
                    i++;
                    yield return c0;
                }
                else
                {
                    c0 = c0 * 2 * (2 * i -1) / (i + 1);
                    i++;
                    yield return c0;
                }
            }

        }
    }

    public class Wielomian : IEnumerable
    {
        private int[] coef;
        public Wielomian(int [] coef)
        {
            this.coef = coef;
        }

        public int wartoscWiel(int x,int[] coef)
        {
            int n = coef.GetLength(0);
            int wynik = coef[n-1];
            for(int i=n-2;i>=0;i--)
            {
                wynik *= x;
                wynik += coef[i];
            }
            return wynik;

        }
        public IEnumerator GetEnumerator()
        {
            int i = 0;
            while (true)
            {
                i++;
                yield return wartoscWiel(i - 1, coef);
            }
        }
    }
}
