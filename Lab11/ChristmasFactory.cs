using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3z
{
    static class ChristmasFactory
    {
        public static bool IsPrime(long a)
        {
            for (long i = 2; i <= Math.Ceiling(Math.Sqrt(a)); i++)
            {
                if (a % i == 0) return false;
            }
            return true;
        }
        public static long NumberFactorization(long a)
        {
            try
            {
                if(IsPrime(a))throw new IncorrectFactorizationException(IncorrectFactorizationException.Exceptiontype.IsPrime);
                for (long i = 2; i < Math.Ceiling(Math.Sqrt(a)); i++)
                {
                    if ((a % i == 0) && IsPrime(i))
                        if(!IsPrime((long)a/i)) throw new IncorrectFactorizationException(IncorrectFactorizationException.Exceptiontype.MoreThan2Factors);
                        else return i;
                }
                return -1;
            }
            catch(IncorrectFactorizationException w) when (w.type== IncorrectFactorizationException.Exceptiontype.IsPrime)
            {
                //Console.WriteLine("IsPrime");
                return a;
            }
            catch (IncorrectFactorizationException w) when (w.type == IncorrectFactorizationException.Exceptiontype.MoreThan2Factors)
            {
                //Console.WriteLine("MoreThan2Factors");
                return 3;
            }

        }
        public static async Task<List<(int,long)>> ManageLetters(List<Letter> lista)
        {
            List<(int, long)> result = new List<(int, long)>();

            foreach (var elem in lista)
            {
                Task<long> factor = Task<long>.Run(() => NumberFactorization(elem.Number));
                long r = await factor;
                result.Add((elem.Id, r));
            }

            return result;
        }
        
    }
    public class IncorrectFactorizationException : SystemException
    {
        public enum Exceptiontype { IsPrime, MoreThan2Factors};
        public Exceptiontype type;
        public IncorrectFactorizationException(Exceptiontype a)
        {
            type = a;
        }
    }
}
