using System;
using System.IO;
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

            int[] input = Array.ConvertAll(sr.ReadLine().Split(), s => int.Parse(s));

            int a = input[0] * input[1];
            int b = input[2] * input[3];

            sw.WriteLine(a + b);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
