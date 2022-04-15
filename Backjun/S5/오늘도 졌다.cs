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

            int[] jam = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] op = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int jamTotal = 0;
            int opTotal = 0;

            bool isCheck = false;

            for (int i = 0; i < 9; i++)
            {
                jamTotal += jam[i];
                if (jamTotal > opTotal) isCheck = true;
                opTotal += op[i];
            }

            if (isCheck) sw.WriteLine("Yes");
            else sw.WriteLine("No");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
