using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TPRLab5
{
   public class Matrix
    {
        double[,] values;
        public int n, m;

        public Matrix(int n, int m, double[,] values = null)
        {
            this.values = values ?? new double[n, m];
            this.n = n;
            this.m = m;
        }

        public Matrix()
        {
        }

        public double this[int i, int j]
        {
            get => values[i, j];
            set => values[i, j] = value;
        }
        //3 сост 3 страгтгии
        public void Load(TextReader tr)
        {
            n = int.Parse(tr.ReadLine());
            m = int.Parse(tr.ReadLine());
            values = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] str = tr.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                    values[i, j] = double.Parse(str[j]);
            }

        }

        public void Save(TextWriter tw)
        {
            tw.WriteLine(n);
            tw.WriteLine(m);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    tw.Write(values[i, j] + " ");
                tw.WriteLine();
            }
        }

        public static Matrix FromList(List<List<double>> list)
        {
            int n = list.Count;
            int m = list[0].Count;
            Matrix mat = new Matrix(n, m);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    mat[i, j] = list[i][j];
            return mat;
        }

    }
}
