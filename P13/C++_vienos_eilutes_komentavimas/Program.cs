using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace C___vienos_eilutes_komentavimas
{
    internal class Program
    {
        const string CFd = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P13\\C++_vienos_eilutes_komentavimas\\bin\\Debug\\Tekstas.txt";
        const string CFr = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P13\\C++_vienos_eilutes_komentavimas\\bin\\Debug\\Rezultatai.txt";
        const string CFa = "C:\\Users\\A&T\\Desktop\\BIT\\C#\\P13\\C++_vienos_eilutes_komentavimas\\bin\\Debug\\Analize.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Apdoroti(CFd,CFr, CFa);
            Console.WriteLine("Programa darbą baigė!!!");
           
        }
        static void Apdoroti(string fv, string fvr, string fa)
        {
            string[] lines = File.ReadAllLines(fv, Encoding.UTF8);
            using (var fr = File.CreateText(fvr))
            {
                using (var far = File.CreateText(fa))
                {
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            string nauja = line;
                            if (BeKomentaru (line, out nauja))
                            {
                                far.WriteLine(nauja);
                            }                              
                            if (nauja.Length > 0)
                            {
                                fr.WriteLine(nauja);
                            }            
                        }
                        else
                        {
                            fr.WriteLine(line);
                        }
                            
                    }
                }
            }
        }
        static bool BeKomentaru (string line, out string nauja)
        {
            nauja = line;
            for (int i = 0; i < line.Length -1; i++)
                if (line [i] == '/' && line [i + 1] == '/')
                {
                    nauja = line.Remove (i);
                    return true;
                }
            return false;
        }
    }
}
