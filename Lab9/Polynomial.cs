using System;

namespace lab09_a
{
    public class Polynomial
    {
        public static Func<double, double> CreatePolynomial(out Func<double, double> derivative, params double[] tab)
        {
            derivative = (x) =>
            {
                double wynik = tab[1];
                for (int i = 2; i < tab.GetLength(0); i++)
                {
                    wynik *= x;
                    wynik += tab[i];
                }
                return wynik;
            };
            return derivative;
        }
        //public static Func<double, double> CreatePolynomial(int degree, Func<double> generatingFunction, out Func<double,double> derivative)
        //{
        //    derivative = (x) => (degree-1)*x * generatingFunction();
        //    return derivative;
        //}
    }
}
