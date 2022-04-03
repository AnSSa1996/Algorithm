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

            while (true)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                if (inputs[0] == 0 && inputs[1] == 0) break;
                if (inputs[0] > inputs[1]) sw.WriteLine("Yes");
                else sw.WriteLine("No");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
