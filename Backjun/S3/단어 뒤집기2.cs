using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string str = sr.ReadLine();

            List<char> temp = new List<char>();
            StringBuilder sb = new StringBuilder();
            bool check = false;
            for (int i = 0; i < str.Length; i++)
            {
                char currentChar = str[i];

                if (check == false && currentChar == '<')
                {
                    if (temp.Count() >= 1) { temp.Reverse(); sb.Append(new string(temp.ToArray())); temp.Clear(); }
                    check = true; sb.Append("<");
                }
                else if (check == true && currentChar != '>') { sb.Append(currentChar); }
                else if (check == true && currentChar == '>') { check = false; sb.Append(">"); }
                else if (check == false && currentChar != '<' && currentChar != ' ') { temp.Add(currentChar); }
                else if (check == false && currentChar == ' ') { temp.Reverse(); sb.Append($"{new string(temp.ToArray())} "); temp.Clear(); }
            }
            if (temp.Count() >= 1) { temp.Reverse(); sb.Append(new string(temp.ToArray())); }

            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}