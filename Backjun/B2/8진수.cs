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
            StringBuilder sb = new StringBuilder();

            string str = sr.ReadLine();
            int remainder = str.Length % 3;

            string firstStr = str.Substring(0, remainder);

            int total = 0;
            for (int i = 0; i < firstStr.Length; i++)
            {
                if (firstStr[i] != '0')
                {
                    total += 1 << (firstStr.Length - i - 1);
                }
            }
            if (total != 0) sb.Append(total);


            for (int i = remainder; i < str.Length - 2; i += 3)
            {
                string curretStr = str.Substring(i, 3);
                int currentN = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (curretStr[j] != '0')
                    {
                        currentN += 1 << (2 - j);
                    }
                }
                sb.Append(currentN);
            }


            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}