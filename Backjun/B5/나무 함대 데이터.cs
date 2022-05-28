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

            sw.WriteLine("SHIP NAME      CLASS          DEPLOYMENT IN SERVICE");
            sw.WriteLine("N2 Bomber      Heavy Fighter  Limited    21        ");
            sw.WriteLine("J-Type 327     Light Combat   Unlimited  1         ");
            sw.WriteLine("NX Cruiser     Medium Fighter Limited    18        ");
            sw.WriteLine("N1 Starfighter Medium Fighter Unlimited  25        ");
            sw.WriteLine("Royal Cruiser  Light Combat   Limited    4         ");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
} 