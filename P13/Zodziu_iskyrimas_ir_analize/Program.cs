using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zodziu_iskyrimas_ir_analize
{
    internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P13\\Zodziu_iskyrimas_ir_analize\\bin\\Debug\\Tekstas.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            char[] skyrikliai = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            Console.WriteLine("Sutampančių žodžių {0,3:d}", Apdoroti(CFd, skyrikliai));
            Console.WriteLine("Programa baigė darbą!");
        }
        static int Apdoroti (string fv, char[] skyrikliai)
        {
            string [] lines = File.ReadAllLines(fv, Encoding.UTF8);
            int sutampa = 0;
            foreach (string line in lines)
                if (line.Length > 0)
                {
                    sutampa += Zodziai(line, skyrikliai);
                }                 
            return sutampa;
        }
        static int Zodziai (string eilute, char[] skyrikliai)
        {
            string[] parts = eilute.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
            int sutampa = 0;
            foreach (string zodis  in parts)
                if (zodis[0] == zodis[zodis.Length -1])  //   Papildymas ->>>  if (zodis.ToUpper()[0] == zodis[zodis.Length - 1])
                    sutampa++;
            return sutampa;
        }
    }
}
