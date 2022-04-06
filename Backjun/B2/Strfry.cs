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

            for (int i = 0; i < N; i++)
            {
                string[] str = sr.ReadLine().Split();

                List<char> leftArray = str[0].ToList();
                List<char> rightArray = str[1].ToList();

                if (leftArray.Count() != rightArray.Count())
                {
                    sw.WriteLine("Impossible");
                    goto end;
                }

                for (int j = 0; j < leftArray.Count(); j++)
                {
                    char c = leftArray[j];
                    if (rightArray.Contains(c))
                    {
                        rightArray.Remove(c);
                        leftArray.Remove(c);
                        j--;
                    }
                    else
                    {
                        sw.WriteLine("Impossible");
                        goto end;
                    }
                }
                sw.WriteLine("Possible");
            end:;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}