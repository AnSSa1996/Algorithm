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
            int total = 0;
            while (true)
            {
                string str = sr.ReadLine();
                if (string.IsNullOrEmpty(str)) break;
                sb.Append(str);
            }
            int[] inputs = Array.ConvertAll(sb.ToString().Split(','), int.Parse);
            sw.WriteLine(inputs.Sum());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}