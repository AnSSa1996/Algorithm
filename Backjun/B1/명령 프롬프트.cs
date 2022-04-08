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

            string str = sr.ReadLine();

            for (int i = 1; i < N; i++)
            {
                StringBuilder tempSb = new StringBuilder();
                string nextStr = sr.ReadLine();
                for (int j = 0; j < nextStr.Length; j++)
                {
                    if (str[j] == nextStr[j]) tempSb.Append(str[j]);
                    else tempSb.Append('?');
                }
                str = tempSb.ToString();
            }

            sw.WriteLine(str);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}