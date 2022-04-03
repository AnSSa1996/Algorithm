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
            StringBuilder sb = new StringBuilder();

            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int cutChicken = inputs[1] * 2 - inputs[0];
                int fineChicken = (inputs[0] - cutChicken) / 2;
                sw.WriteLine($"{cutChicken} {fineChicken}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
