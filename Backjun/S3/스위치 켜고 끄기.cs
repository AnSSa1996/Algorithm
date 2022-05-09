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

            int numCount = int.Parse(sr.ReadLine());
            int[] swithchs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int gender = inputs[0];
                int number = inputs[1];

                if (gender == 1)
                {
                    for (int start = (number - 1); start < numCount; start += number)
                        swithchs[start] = swithchs[start] == 0 ? 1 : 0;
                }
                else
                {
                    int index = number - 1;
                    swithchs[index] = swithchs[index] == 0 ? 1 : 0;
                    for (int start = 1; start < numCount; start++)
                    {
                        if (index - start < 0 || index + start >= numCount) break;
                        else
                        {
                            if (swithchs[index - start] == swithchs[index + start])
                            {
                                swithchs[index - start] = swithchs[index - start] == 0 ? 1 : 0;
                                swithchs[index + start] = swithchs[index + start] == 0 ? 1 : 0;
                            }
                            else break;
                        }
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= numCount; i++)
            {
                if (i % 20 == 0) { sb.AppendLine($"{swithchs[i - 1]}"); continue; }
                sb.Append($"{swithchs[i - 1]} ");
            }

            if (sb.Length != 0) sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
