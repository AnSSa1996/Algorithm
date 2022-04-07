using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                string str = sr.ReadLine();
                int a = inputs[0];
                int b = inputs[1];

                StringBuilder tempSb = new StringBuilder();

                for (int j = 0; j < str.Length; j++)
                {
                    char c = str[j];
                    char newChar = (char)((a * (c - 'A') + b) % 26 + 'A');

                    tempSb.Append(newChar);
                }
                sw.WriteLine(tempSb);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}