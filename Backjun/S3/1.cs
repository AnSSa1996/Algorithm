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
                string str = sr.ReadLine();
                if (string.IsNullOrEmpty(str)) break;

                int num = 1;
                int div = int.Parse(str);

                int cnt = 1;
                while (true)
                {
                    num = num * 10 + 1;
                    num %= div;
                    cnt++;
                    if (num % div == 0) break;
                }

                sw.WriteLine(cnt);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
