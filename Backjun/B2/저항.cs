using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            Dictionary<string, int> colors = new Dictionary<string, int>();

            colors.Add("black", 0);
            colors.Add("brown", 1);
            colors.Add("red", 2);
            colors.Add("orange", 3);
            colors.Add("yellow", 4);
            colors.Add("green", 5);
            colors.Add("blue", 6);
            colors.Add("violet", 7);
            colors.Add("grey", 8);
            colors.Add("white", 9);

            string first = sr.ReadLine();
            string second = sr.ReadLine();
            string third = sr.ReadLine();

            long num = (colors[first] * 10 + colors[second]) * (long)Math.Pow(10, colors[third]);
            sw.WriteLine(num);


            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}