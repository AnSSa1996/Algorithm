using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());


            float currentT = float.Parse(sr.ReadLine());

            while (true)
            {
                float nextT = float.Parse(sr.ReadLine());
                if (nextT == 999) break;
                float dif = nextT - currentT;
                sw.WriteLine($"{dif:f2}");
                currentT = nextT;
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
