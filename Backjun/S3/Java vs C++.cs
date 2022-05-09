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

            string input = sr.ReadLine();

            bool check = true;
            if (input.Contains("_"))
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '_')
                    {
                        if (i == 0) { check = false; goto end; }
                        if (i == input.Length - 1) { check = false; goto end; }
                        if (input[i + 1] == '_') { check = false; goto end; }
                    }
                }

                string[] str = input.Split('_');
                foreach (var s in str)
                {
                    foreach (char c in s) if (c >= 'A' && c <= 'Z')
                        { check = false; goto end; }
                }
                for (int i = 0; i < str.Length; i++)
                {
                    if (i == 0) sb.Append(str[i]);
                    else
                    {
                        char[] cArray = str[i].ToArray();
                        cArray[0] = Char.ToUpper(cArray[0]);
                        sb.Append($"{new string(cArray)}");
                    }
                }

            end:
                if (check) sw.WriteLine(sb);
                else sw.WriteLine("Error!");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                char[] charArray = input.ToArray();
                bool check2 = true;
                for (int i = 0; i < charArray.Length; i++)
                {
                    if (i == 0 && charArray[i] >= 'A' && charArray[i] <= 'Z') { check2 = false; goto end2; }
                    if (charArray[i] >= 'A' && charArray[i] <= 'Z') { sb.Append($"_{Char.ToLower(charArray[i])}"); }
                    else sb.Append(charArray[i]);
                }

            end2:
                if (check2) sw.WriteLine(sb);
                else sw.WriteLine("Error!");
            }


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
