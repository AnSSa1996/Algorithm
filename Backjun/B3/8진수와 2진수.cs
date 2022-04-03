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

            string bit8 = sr.ReadLine();

            for (int i = 0; i < bit8.Length; i++)
            {
                string bit = $"{int.Parse(Convert.ToString(int.Parse(bit8[i].ToString()), 2)):000}";
                sb.Append(bit);
            }

            if (sb[0] == '0') sb.Remove(0, 1);
            if (sb[0] == '0') sb.Remove(0, 1);
            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
