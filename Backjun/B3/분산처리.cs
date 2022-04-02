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

            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int num = inputs[0] % 10;
                int pow = inputs[1] % 4 == 0 ? 4 : inputs[1] % 4;

                int result = (int)Math.Pow(num, pow) % 10;
                if (result == 0) sw.WriteLine(10);
                else sw.WriteLine(result);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
