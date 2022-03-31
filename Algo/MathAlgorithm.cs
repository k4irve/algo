using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Algo
{
    internal class MathAlgorithm
    {
        double x1;
        double x2;
        double x3;
        double imaginary;

        public MathAlgorithm(double x1, double x2, double x3)
        {
            this.x1 = x1;
            this.x2 = x2; 
            this.x3 = x3;
            this.imaginary = 0;
        }
        public MathAlgorithm(double x1, double x2, double x3, double imaginary)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.imaginary = imaginary;
        }

        
        public static void PrintInfo(MathAlgorithm values,double delta, string stage)
        {
            switch(stage)
            {
                case "<0":
                    {
                        Console.WriteLine("Delta < 0");
                        Console.WriteLine($"X1 = {values.x1}");
                        Console.WriteLine($"X2 = {values.x2}");
                        Console.WriteLine($"X3 = {values.x3}");
                        break;
                    }
                case ">0":
                    {
                        Console.WriteLine("Delta > 0");
                        Console.WriteLine($"X1 = {values.x1}");
                        Console.WriteLine($"X2 = {values.x2} {values.imaginary}i");
                        Console.WriteLine($"X3 = {values.x3} {values.imaginary}i");
                        break;
                    }
                case "=0":
                    {
                        Console.WriteLine("Delta == 0");
                        Console.WriteLine($"X1 = {values.x1}");
                        Console.WriteLine($"X2 = {values.x2}");
                        Console.WriteLine($"X3 = {values.x3}");
                        break;
                    }
                default:
                    break;
            }
        }

        public static MathAlgorithm StartAlgorithm()
        {
            
            double a = 0, b, c, d;
            double w;
            double p , q;
            double delta;

            do
            {
                Console.Write("Insert parameter a: ");
                a = double.Parse(Console.ReadLine());
                if (a == 0)
                {
                    
                    Console.WriteLine("Parameter 'a' can't be 0");
                    Console.ReadLine();
                    Console.Clear();
                }
            }while (a == 0);
            Console.Write("Insert parameter b: ");
            b = double.Parse(Console.ReadLine());
            Console.Write("Insert parameter c: ");
            c = double.Parse(Console.ReadLine());
            Console.Write("Insert parameter d: ");
            d = double.Parse(Console.ReadLine());
            w = (-b) / (3 * a);
            p = ((3 * a * Math.Pow(w, 2)) + (2 * b * w) + c) / a;
            q = ((a * Math.Pow(w, 3) + b) * Math.Pow(w, 2) + c * w + d) / a;
            delta = (Math.Pow(p, 3) / 27) + (Math.Pow(q, 2) / 4);

            if (delta < 0)
                return MathAlgorithm.LessThanZero(w, p, q, delta);
            else if (delta > 0)
                return MathAlgorithm.MoreThanZero(w, p, q, delta);
            else if (delta == 0)
                return MathAlgorithm.EqualZero(w, p, q, delta);
            else
                return new MathAlgorithm(0, 0, 0);
            
        }
        
        public static MathAlgorithm LessThanZero(double w, double p, double q, double delta)
        {
            double fi = Math.Acos((3 * q / 2 * p * Math.Sqrt((-p / 3))));
            
            double x1 = w + 2 * Math.Sqrt(-p / 3) *  Math.Cos(fi / 3);
            double x2 = w + 2 * Math.Sqrt(-p / 3) *  Math.Cos((fi / 3) + (((double)2) / 3) * (double)(Math.PI));
            double x3 = w + 2 * Math.Sqrt(-p / 3) *  Math.Cos((fi / 3) + (((double)4) / 3) * (double)(Math.PI));
            MathAlgorithm temp = new MathAlgorithm(x1, x2, x3);
            MathAlgorithm.PrintInfo(temp, delta, "<0");
            return temp;
        }
        public static MathAlgorithm MoreThanZero(double w, double p, double q, double delta)
        {
            double u, v;
            
            u = NRoot.Count(((-q / 2) + Math.Sqrt(delta)), 3);
            v = NRoot.Count(((-q / 2) - Math.Sqrt(delta)), 3);

            double imaginary = (Math.Sqrt(3) / 2) * (u - v);

            double x1 = u + v + w;
            double x2 = (((double)-1) / 2) * (u + v) + w;
            double x3 = (((double)-1) / 2) * (u + v) + w;

            MathAlgorithm temp = new MathAlgorithm(x1, x2, x3, imaginary);
            MathAlgorithm.PrintInfo(temp, delta, ">0");
            return temp;
        }
        public static MathAlgorithm EqualZero(double w, double p, double q, double delta)
        {
            double x1 = w - 2 * NRoot.Count((q / 2), 3);
            double x2 = w + NRoot.Count((q / 2), 3);
            double x3 = x2;

            MathAlgorithm temp = new MathAlgorithm(x1, x2, x3);
            MathAlgorithm.PrintInfo(temp, delta, "=0");
            return temp;
        }
    }
}
