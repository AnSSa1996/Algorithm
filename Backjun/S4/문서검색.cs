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

            string str = sr.ReadLine();
            string find = sr.ReadLine();

            int cnt = 0;
            while (true)
            {
                if (!str.Contains(find)) break;
                else
                {
                    int index = str.IndexOf(find);
                    str = str.Substring(index + find.Length, str.Length - find.Length - index);
                    cnt++;
                }
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
