using System;

namespace ConsoleApplication6
{
    class complex
    { 
        double real,im;
        public complex()
        {
            real = 0;
            im = 0;
        }
        public complex(double real_, double im_)
        {
            real = real_;
            im = im_;
        }

        public double Real
        {
            get
            {
                return real;
            }
            set
            {
                real = value;
            }
        }

        public double Im
        {
            get
            {
                return im;
            }
            set
            {
                im = value;
            }
        }

        public static complex Sum(complex x, complex y)
        {
            complex result = new complex();
            result.Real = x.Real + y.Real;
            result.Im = x.Im + y.Im;
            return result;
        }

        public static complex Difference(complex x, complex y)
        {
            complex result = new complex();
            result.Real = x.Real - y.Real;
            result.Im = x.Im - y.Im;
            return result;
        }

        public static complex Multiplication(complex x, complex y)
        {
            complex result = new complex();
            result.Real = x.Real * y.Real - x.Im * y.Im;
            result.Im = x.Im * y.Real + x.Real * y.Im;
            return result;
        }

        public static complex Division(complex x, complex y)
        {
            complex result = new complex();
            double a = x.Real;
            double b = x.Im;
            double c = y.Real;
            double d = y.Im;
            result.Real = (a * c + b * d) / (c * c + d * d) ;
            result.Im = (b * c - a * d) / (c * c + d * d);
            return result;
        }

        public static double Abs(complex x)
        {
            double a = x.Real;
            double b = x.Im;
            double result = Math.Pow(a * a + b * b, 0.5);
            return result;
        }

        public static complex Pow(complex x, int n)
        {
            complex result = new complex();
            double r = Abs(x);
            double fi = Math.Tan(x.Im / x.Real);
            result.Real = Math.Pow(r, n) * Math.Cos(n * fi);
            result.Im = Math.Pow(r, n) * Math.Sin(n * fi);
            return result;
        }

        public static complex[] Sqr(complex x, int n)
        {
            complex[] result = new complex[n];
            double r = Abs(x);
            double fi = Math.Tan(x.Im / x.Real);
            for (int i = 0; i < n; i++)
            {
                result[i] = new complex();
                result[i].Real = Math.Pow(r, 1.0 / n) * Math.Cos((fi + 2 * Math.PI * i) / n);
                result[i].Im = Math.Pow(r, 1.0 / n) * Math.Sin((fi + 2 * Math.PI * i) / n);
            }
            return result;
        }
        public void Print()
        {
            string str = real.ToString("N");
            if (im >= 0)
            {
                str += " + " + im.ToString("N") + "i";
               
            }
            else
            {
                str +=" - " + Math.Abs(im).ToString("N") + "i";
            }
            Console.WriteLine(str);
        }
    }
    class Program
    {
        static void Main()
        {
            complex z1 = new complex(8,0);
            complex[] res;
            res = complex.Sqr(z1, 2);
            for (int i = 0; i < res.Length; i++)
                res[i].Print();
            z1.Print();
            complex z2 = new complex(-4.5, 3);
            complex z3 = new complex();
            //z.Real = 10; z.Im = 2;
            z3 = complex.Sum(z1,z2);
            z3.Print();
            //Console.WriteLine(z3.Real);
            Console.ReadLine();
        }
    }
}
