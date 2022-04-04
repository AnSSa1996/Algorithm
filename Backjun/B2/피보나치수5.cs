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

            int N = int.Parse(sr.ReadLine());
            int fi = Fibo(N);

            sw.WriteLine(fi);

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        public static int Fibo(int n)
        {
            if (n == 0) return 0;
            else if (n == 1 || n == 2) return 1;
            else return Fibo(n - 1) + Fibo(n - 2);
        }
    }
}
