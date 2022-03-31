using System;
using System.IO;
using System.Numerics;
using System.Text;

namespace ProgrammersLv1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            int price = int.Parse(sr.ReadLine());

            int first = price * 78 / 100;
            int second = price - (price * 44 / 1000);

            sw.WriteLine($"{first} {second}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
