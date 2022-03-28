using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    internal class NRoot
    {
        public static double Count(double A, int N)
        {
            double epsilon = 0.00001d;
            double n = N;
            double x = A / n;
            while (Math.Abs(A - Math.Pow(x, N)) > epsilon)
            {
                x = (1.0d / n) * ((n - 1) * x + (A / (Math.Pow(x, N - 1))));
            }
            return x;
        }
    }
}
