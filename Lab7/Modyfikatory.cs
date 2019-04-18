using System;
using System.Collections;
namespace Lab8
{
    /// <summary>
    /// Interfejs klas modyfikujących sekwencje
    /// </summary>
    public interface IModifier
    {
        /// <summary>
        /// Nazwa modyfikatora
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Metoda modyfikuje sekwencje
        /// </summary>
        /// <param name="sequence">Sekwencja do modyfikacji</param>
        /// <returns>Zmodyfikowana sekwencja</returns>
        IEnumerable Modify(IEnumerable sequence);
    }

    public class PoczatkoweN: IModifier
    {
        int N;
        string IModifier.Name { get { return "Poczatkowe " + N + " liczb."; } } 

        public PoczatkoweN (int N)
        {
            this.N = N;
        }
        public IEnumerable Modify(IEnumerable sequence)
        {
            int i = 0;
            foreach(var elem in sequence)
            {
                if (i == N) break;
                else
                {
                    i++;
                    yield return elem;
                }
            }
        }
    }

    public class TransformacjaLiniowa : IModifier
    {
        int a;
        int b;
        string IModifier.Name { get { return "Transformacja liniowa."; } }

        public TransformacjaLiniowa(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public IEnumerable Modify(IEnumerable sequence)
        {
            foreach (var elem in sequence)
            {
                yield return (int)elem * a + b;
            }
        }
    }

    public class TylkoRozne : IModifier
    {
        string IModifier.Name { get { return "Unikalne wartosci."; } }
        public IEnumerable Modify(IEnumerable sequence)
        {
            int prev = 0;
            int i = 0;
            foreach (var elem in sequence)
            {
                if(i==0)
                {
                    i++;
                    prev = (int)elem;
                    yield return elem;
                    continue;
                }
                if (prev != (int)elem)
                {
                    yield return elem;
                }
                prev = (int)elem;
            }
        }
    }

    public class LiczbyPierwsze : IModifier
    {
        string IModifier.Name { get { return "Liczby pierwsze z sekwencji."; } }
        public IEnumerable Modify(IEnumerable sequence)
        {
            foreach(var elem in sequence)
            {
                if ((int)elem == 0 || (int)elem == 1) continue;
                if ((int)elem == 2 || (int)elem == 3)
                {
                    yield return elem;
                    continue;
                }
                for (int i = 2; i*i < (int)elem; i++)
                {
                    if ((int)elem % i == 0) continue;
                    else
                    {
                        yield return elem;
                        continue;
                    }

                }
            }
        }
    }

    public class MinimaLokalne : IModifier
    {
        string IModifier.Name { get { return "Minima lokalne."; } }

        public bool IsMin(int a, int b, int c)
        {
            if (b < a && b < c) return true;
            return false;
        }
        public IEnumerable Modify(IEnumerable sequence)
        {
            IModifier unique = new TylkoRozne();
            var a = unique.Modify(sequence);
            int ile = 0;
            int i = 0;
            int prev1 = int.MaxValue, prev2 = int.MaxValue;     
            foreach (var elem in a)
            {
                ile++;
            }


            foreach (var elem in a)
            {
                if(ile==1)
                {
                    yield return elem;
                    continue;
                }
                if(ile==2)
                {
                    if(i==0)
                    {
                        prev1 = (int)elem;
                        i++;
                        continue;

                    }
                    if(i==1)
                    {
                        i++;
                        yield return prev1 < (int)elem ? prev1 : elem;
                        continue;
                    }
                }
                if (i == 0)
                {
                    prev1 = (int)elem;
                    i++;
                    continue;

                }
                if (i == 1)
                {
                    prev2 = (int)elem;
                    yield return prev1 < (int)elem ? prev1 : elem;
                    i++;
                    continue;
                }
                if(i==(ile-1))
                {
                    if((int)elem<prev2)
                    {
                        i++;
                        yield return elem;
                        continue;
                    }
                }
                if (IsMin(prev1,prev2,(int)elem))
                {
                    i++;
                    yield return prev2;
                }
                prev1 = prev2;
                prev2 = (int)elem;
            }
        }
    }
}
