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

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string str = sr.ReadLine();

                if (str[str.Length / 2 - 1] == str[str.Length / 2]) sw.WriteLine("Do-it");
                else sw.WriteLine("Do-it-Not");
            }


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}