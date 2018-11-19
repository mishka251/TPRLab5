using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace TPRLab5
{
    public class PFunc
    {
        double q, s, sigma;
        int funType;
        public P func;


        public PFunc(int type, double q, double s, double sigma)
        {
            funType = type;
            this.q = q;
            this.s = s;
            this.sigma = sigma;
            func = createFunc();
        }

        public void Save(TextWriter tw)
        {
            tw.WriteLine(funType);
            tw.WriteLine(q);
            tw.WriteLine(s);
            tw.WriteLine(sigma);
        }
        public static PFunc Load(TextReader tr)
        {
            int funType = int.Parse(tr.ReadLine());
            double q = double.Parse(tr.ReadLine());
            double s = double.Parse(tr.ReadLine());
            double sigma = double.Parse(tr.ReadLine());
            return new PFunc(funType, q, s, sigma);
        }


        P createFunc()
        {
            switch (funType)
            {
                case 0: return createP1();
                case 1: return createP2(q);
                case 2: return createP3(s);
                case 3: return createP4(q, s);
                case 4: return createP5(q, s);
                case 5: return createP6(sigma);
                default: throw new Exception("Unknown func");
            }
        }

        P createP1()
        {
            return ((double d) => d <= 0 ? 0 : 1);
        }
        P createP2(double q)
        {
            return ((double d) => d <= q ? 0 : 1);
        }
        P createP3(double s)
        {
            return (double d) => d <= 0 ? 0 : d < s ? d / s : 1;
        }
        P createP4(double q, double s)
        {
            return (double d) => d <= q ? 0 : d <= s ? 0.5 : 1;
        }
        P createP5(double q, double s)
        {
            return (double d) => d <= q ? 0 : d <= s ? (d - q) / (s - q) : 1;
        }
        P createP6(double s)
        {
            return (double d) => d <= 0 ? 0 : 1 - Math.Exp(-d * d / (2 * s * s));
        }


    }
}
