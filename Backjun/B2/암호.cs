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
            string password = sr.ReadLine();

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (c == ' ')
                {
                    sb.Append(' ');
                    continue;
                }
                int pass = password[i % (password.Length)] - 'a' + 1;

                char result = c - pass < 'a' ? (char)(26 + c - pass) : (char)(c - pass);
                sb.Append(result);
            }

            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}