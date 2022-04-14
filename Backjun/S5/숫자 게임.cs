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

            int max = -1;
            int index = 0;

            for (int i = 1; i <= N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int a = 0; a < 3; a++)
                {
                    int total = 0;
                    for (int b = a + 1; b < 4; b++)
                    {
                        for (int c = b + 1; c < 5; c++)
                        {
                            total = inputs[a] + inputs[b] + inputs[c];
                            int currentNum = total.ToString().Last() - '0';
                            if (currentNum >= max)
                            {
                                max = currentNum;
                                index = i;
                            }
                            if (currentNum == 9) goto end;
                        }
                    }
                }
            end:;
            }

            sw.WriteLine(index);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
