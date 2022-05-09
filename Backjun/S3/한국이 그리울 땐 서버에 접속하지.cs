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

            int T = int.Parse(sr.ReadLine());

            StringBuilder sb = new StringBuilder();
            sb.Append("^");
            sb.Append(sr.ReadLine());
            sb.Replace("*", "[a-z]*");
            sb.Append("$");

            for (int i = 0; i < T; i++)
            {
                string str = sr.ReadLine();

                if (Regex.IsMatch(str, sb.ToString())) sw.WriteLine("DA");
                else sw.WriteLine("NE");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
