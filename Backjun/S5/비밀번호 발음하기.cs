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
            char[] vol = new char[5] { 'a', 'e', 'i', 'o', 'u' };

            while (true)
            {
                string str = sr.ReadLine();
                if (str == "end") break;

                bool result = true;
                int repeatV = 0;
                int repeatC = 0;
                char sameChar = str[0];

                if (vol.Contains(sameChar)) repeatV++;
                else repeatC++;

                if (str.Count(x => vol.Contains(x)) >= 1)
                {
                    for (int i = 1; i < str.Length; i++)
                    {
                        if (sameChar != str[i] || str[i] == 'e' || str[i] == 'o')
                        {
                            if (vol.Contains(str[i]))
                            {
                                repeatV++;
                                repeatC = 0;
                            }
                            else
                            {
                                repeatC++;
                                repeatV = 0;
                            }
                            if (repeatC >= 3 || repeatV >= 3) { result = false; break; }
                        }
                        else
                        {
                            result = false; break;
                        }
                        sameChar = str[i];
                    }
                }
                else result = false;

                if (result) sw.WriteLine($"<{str}> is acceptable.");
                else sw.WriteLine($"<{str}> is not acceptable.");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
