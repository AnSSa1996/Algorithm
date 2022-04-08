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

            List<string> lst = new List<string>();

            int maxLength = 0;

            for (int i = 0; i < 5; i++)
            {
                string str = sr.ReadLine();
                maxLength = Math.Max(maxLength, str.Length);
                lst.Add(str);
            }


            for (int x = 0; x < maxLength; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    try
                    {
                        sb.Append(lst[y][x]);
                    }
                    catch (Exception e)
                    {

                    }
                }
            }

            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}