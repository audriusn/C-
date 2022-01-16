using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perrašyta_su_metodai_1._4_užduotis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x;

            Console.Write("Įveskite x reikšmę: ");
            x = double.Parse(Console.ReadLine());
            Console.Clear(); // išvalo langą
            Console.SetCursorPosition(0, 0); // Nustatto pradinę žymeklio padėtį
            Console.WriteLine("Reikšmė reiksme x = {0,6:f2}, fx = {1,8:f3}",x, Fx10(x));
        }
        //1.4.0 
        static double Fx0(double sk1)
        {
            if (sk1 >= -2 && sk1 <= 0)
                return Math.Pow(Math.Exp(1), sk1);
            else if (sk1 > 0 && sk1 < 2)
                return (2 * Math.Pow(sk1, 2)) + 1;
            else
                return (2 * Math.Pow(sk1, 2)) + 1;
        }

        //1.4.1
        static double Fx1(double sk1)
        {
            if (sk1 >= -3 && sk1 <= 0)
                return Math.Pow(Math.Exp(1), sk1);
            else if (sk1 > 0 && sk1 <= 1)
                return (5*sk1-7);
            else
                return Math.Sqrt(sk1+1);
        }

        //1.4.2
        static double Fx2(double sk1)
        {
            if (sk1 >= -4 && sk1 <= 0)
                return Math.Cos(sk1);
            else if (sk1 > 0 && sk1 <= 4)
                return 1 / (Math.Pow(sk1+5,3));
            else
                return Math.Sqrt((Math.Pow(sk1,2)+1));
        }
        //1.4.3
        static double Fx3(double sk1)
        {
            if (sk1 >= -5 && sk1 <= 0)
                return sk1 + 2 * Math.Pow(sk1, 2);
            else
                if (sk1 > 0 && sk1 < 3)
                return (Math.Pow(sk1, 2) + 4);
            else
                return Math.Sqrt(2 * Math.Pow(sk1, 2) + 3);
        }

        //1.4.4

        static double Fx4(double sk1)
        {
            if (sk1 >= -1 && sk1 <= 0)
                return Math.Cos(Math.Pow(sk1, 2));
            else
                if (sk1 > 0 && sk1 < 1)
                return 4 * Math.Pow(sk1, 2) + 3;
            else
                return Math.Sqrt(Math.Pow(sk1, 2) + sk1 + 4);
        }

        //1.4.5
        static double Fx5(double sk1)
        {
            if (sk1 >= -1 && sk1 < 0)
                return 1 / (sk1 + 5);
            else
                if (sk1 >= 0 && sk1 < 1)
                return sk1 + 1;
            else
               return Math.Sqrt(Math.Pow(sk1, 2) + sk1 + 1);
        }

        //1.4.6
        static double Fx6(double sk1)
        {
            if (sk1 >= -1 && sk1 < 0)
                return Math.Pow(Math.Sin(sk1), 2);
            else
                if (sk1 >= 0 && sk1 < 1)
                return Math.Pow((sk1 - 1), 2);
            else
                return Math.Pow(sk1, 2) + sk1 + 1;
        }

        //1.4.7
        static double Fx7(double sk1)
        {
            if (sk1 >= -2 && sk1 < 0)
                return 3.2 * Math.Pow(sk1, 2);
            else
                if (sk1 >= 0 && sk1 <= 1)
                return Math.Sin(sk1 + 1) * Math.Sin(sk1 + 1);
            else
                return (3 * Math.Pow(sk1, 2)) - 1;
        }

        //1.4.8
        static double Fx8(double sk1)
        {
            if (sk1 >= -2 && sk1 < 0)
               return 3.2 * Math.Pow(sk1, 2);
            else
                if (sk1 >= 0 && sk1 <= 1)
                return Math.Pow(Math.Sin(sk1 + 1), 2);
            else
              return Math.Sqrt(sk1 + 5);
        }


        //1.4.9
        static double Fx9(double sk1)
        {
            if (sk1 >= -4 && sk1 < -2)
                return 1 / sk1;
            else
                if (sk1 >= -2 && sk1 <= 2)
                return Math.Cos(sk1);
            else
                return (2 * sk1) + 4;
        }

        //1.4.10
        static double Fx10(double sk1)
        {
            if (sk1 >= -5 && sk1 < 0)
                return 1 / Math.Pow(sk1, 2);
            else
                if (sk1 >= 0 && sk1 <= 2)
                return Math.Sin(sk1 + 1);
            else
                return Math.Sqrt(2 * sk1);
        }


        //1.4.11
        static double Fx11(double sk1)
        {
            if (sk1 >= -6 && sk1 <= -1)
               return 1 / (sk1 - 3);
            else
                if (sk1 > -1 && sk1 <= 3)
             return Math.Pow(sk1, 2) + 6;
            else
                return (sk1 * 2) + 3;
        }



    }
}

