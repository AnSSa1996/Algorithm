using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int A = inputs[0];
            int B = inputs[1];
            int C = inputs[2];

            int students = inputs[3];

            bool isCan = false;
            for (int a = 0; a <= students; a += A)
            {
                for (int b = 0; b <= students; b += B)
                {
                    for (int c = 0; c <= students; c += C)
                    {
                        if (a + b + c == students)
                        {
                            isCan = true;
                            goto end;
                        }
                    }
                }
            }


        end:
            if (isCan) sw.WriteLine(1);
            else sw.WriteLine(0);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
