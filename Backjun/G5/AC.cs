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

            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                string p = sr.ReadLine();
                int N = int.Parse(sr.ReadLine());
                string[] stringArray = sr.ReadLine().Trim('[', ']').Split(',');

                int left = 0; int right = N;
                int length = N;
                bool reverse = false;
                bool error = false;
                for (int index = 0; index < p.Length; index++)
                {
                    char c = p[index];
                    if (c == 'R') reverse = !reverse;
                    if (c == 'D')
                    {
                        if (length == 0)
                        {
                            error = true;
                            break;
                        }
                        length--;
                        if (reverse) right--;
                        else left++;
                    }
                }

                var result = stringArray[left..right];
                if (error)
                {
                    sw.WriteLine("error");
                }
                else if (reverse)
                {
                    var reverseStr = result.Reverse();
                    sw.WriteLine($"[{string.Join(',', reverseStr)}]");
                }
                else
                {
                    sw.WriteLine($"[{string.Join(',', result)}]");
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}