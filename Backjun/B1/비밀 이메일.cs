using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string str = sr.ReadLine();

            int R = 0;
            int C = 0;

            for (int i = 1; i * i <= str.Length; i++)
            {
                if (str.Length % i == 0)
                {
                    R = i;
                    C = str.Length / i;
                }
            }

            char[,] charlst = new char[R, C];

            int cnt = 0;
            for (int c = 0; c < C; c++)
            {
                for (int r = 0; r < R; r++)
                {
                    charlst[r, c] = str[cnt];
                    cnt++;
                }
            }

            StringBuilder resultSb = new StringBuilder();
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    resultSb.Append(charlst[r, c]);
                }
            }

            sw.WriteLine(resultSb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}