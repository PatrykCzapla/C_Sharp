using System;

namespace MatrixLibrary
{
    public abstract class Matrix
    {
        public int Rows;
        public int Columns;

        public Matrix(int row,int col, double[,] tab)
        {
            if (tab == null||row<=0||col<=0||tab.GetLength(0)!=row||tab.GetLength(1)!=col)
            {
                Rows = -1;
                Columns = -1;
                return;
            }

            Rows = row;
            Columns = col;
        }

        public abstract double GetValue(int row, int column);
        public abstract void SetValue(int row, int column, double value);

        public void Print()
        {
            if (Columns == -1) return;
            for(int i=0; i<Rows;i++)
            {
                for(int j=0;j<Columns;j++)
                {
                    Console.Write("{0}  ",GetValue(i,j));
                }
                Console.WriteLine();
            }
        }      
    }

    public class ArrayMatrix: Matrix
    {
        private double[,] tab;
        public ArrayMatrix(int row, int col, double[,] tab):base(row,col,tab)
        {
            if (tab == null || Rows==-1)
            {
                this.tab = null;
                return;
            }

            
            this.tab = new double[Rows,Columns];

            for(int i=0; i<Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    this.tab[i, j] = tab[i, j];
                }
            }

        }
        public override double GetValue(int row, int column)
        {
            if (tab == null  || row >= Rows || column >= Columns || row < 0 || column < 0)
            {
                return double.MinValue;
            }
            else return this.tab[row, column];
        }
        public override void SetValue(int row, int column, double value)
        {
            if (tab == null || row >= Rows || column >= Columns || row < 0 || column < 0)
            {
                return;
            }
            else
            {
                this.tab[row, column] = value;
            }

        }
    }
     
    public class SparseMatrix : Matrix
    {
        public int[] wiersz;
        public int[] kolumna;
        private double[] wartosci;

        public SparseMatrix(int row, int column, double[,] tab):base(row,column,tab)
        {
            if (tab == null || Rows == -1)
            {
                wiersz = null;
                kolumna = null;
                wartosci = null;
                return;
            }

            int ileniezer = 0;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (tab[i, j] != 0) ileniezer++;
                }
            }

            wiersz = new int[ileniezer];
            kolumna = new int[ileniezer];
            wartosci = new double[ileniezer];

            int iter = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (tab[i, j] != 0)
                    {
                        wiersz[iter] = i;
                        kolumna[iter] = j;
                        wartosci[iter] = tab[i, j];
                        iter++;
                    }
                }
            }



        }


        public override double GetValue(int row, int column)
        {
            if (wiersz == null || row >= Rows || column >= Columns || row < 0 || column < 0)
            {
                return double.MinValue;
            }
            
            for (int i=0;i<wiersz.GetLength(0);i++)
            {
                if(wiersz[i]==row&&kolumna[i]==column)
                {
                    return wartosci[i];
                }
            }

            return 0;
        }
        public override void SetValue(int row, int column, double value)
        {
            if (wiersz == null || row >= Rows || column >= Columns || row < 0 || column < 0)
            {
                return;
            }

            for (int i = 0; i < wiersz.GetLength(0); i++)
            {
                if (wiersz[i] == row && kolumna[i] == column)
                {
                    wartosci[i] = value;
                }
            }
        }
    }

}
