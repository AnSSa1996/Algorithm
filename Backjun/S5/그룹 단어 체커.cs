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

            int N = int.Parse(sr.ReadLine());

            int cnt = 0;

            for (int i = 0; i < N; i++)
            {
                List<char> checkChar = new List<char>();
                char[] charArray = sr.ReadLine().ToArray();
                bool check = true;

                char currentChar = charArray[0];
                checkChar.Add(currentChar);
                for (int j = 1; j < charArray.Length; j++)
                {
                    if (currentChar == charArray[j]) continue;
                    if (!checkChar.Contains(charArray[j]))
                    {
                        checkChar.Add(charArray[j]);
                        currentChar = charArray[j];
                    }
                    else
                    {
                        check = false;
                        break;
                    }
                }
                if (check) cnt++;
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}