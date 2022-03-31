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


            int C = A * (B % 10);
            int D = A * ((B / 10) % 10);
            int E = A * (B / 100);
            int F = A * B; ;

            sw.WriteLine(C);
            sw.WriteLine(D);
            sw.WriteLine(E);
            sw.WriteLine(F);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
