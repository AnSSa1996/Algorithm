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

            int A = int.Parse(sr.ReadLine());
            int B = int.Parse(sr.ReadLine());

            int dif = B - A;

            sw.WriteLine(B+dif);
            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
