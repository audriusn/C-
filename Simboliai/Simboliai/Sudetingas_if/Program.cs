using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

////------------------------------------------------------------
//// Sudėtingas if sakinys
////------------------------------------------------------------
//namespace Sudetingas_if
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            double fx;
//            int a;
//            double x;
//            Console.Write(" Įveskite a reikšmę (tik sveikas skaičius): ");
//            a = int.Parse(Console.ReadLine());
//            Console.Write(" Įveskite x reikšmę: ");
//            x = double.Parse(Console.ReadLine());
//            Console.Clear(); // Išvalo langą
//            Console.SetCursorPosition(5, 6); // Nustato pradinę žymeklio padėtį
//            if (x <= 0)
//                fx = a * Math.Exp(-x);
//            else
//            if (x < 1)
//                fx = 5 * a * x - 7;
//            else
//                fx = Math.Pow(x + 1, 0.5);
//            Console.WriteLine(" Reikšmė a = {0,3:d}, reikšmė x = {1,6:f2}, fx = {2,8:f3}",
//            a, x, fx);
//        }
//    }
//}
//------------------------------------------------------------

//------------------------------------------------------------
//Savarankisko darbo uzduotis P01_3
//------------------------------------------------------------
namespace Sudetingas_if
{
    class Program
    {
        static void Main(string[] args)
        {
          double fx;
            double x;
            Console.Write(" Įveskite x reikšmę: ");
            x = double.Parse(Console.ReadLine());
            if (-6 <= x && x <= -1)
                    fx = 1 / (x - 3);
            else if (-1 < x && x <= 3)
                fx = Math.Pow(x, 2.0) + 6;
            else
            {
                fx = 2 * x + 3;
                Console.Write(" Reikšmė x = {0,3:d}, fx = {1,8:f3}", x, fx);
            }
        }
    }
}


