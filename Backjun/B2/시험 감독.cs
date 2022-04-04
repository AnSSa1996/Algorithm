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

            long N = long.Parse(sr.ReadLine());
            long[] students = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            long[] inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            long B = inputs[0];
            long C = inputs[1];

            long count = 0;

            for (long i = 0; i < N; i++)
            {
                long currentStudents = students[i] - B;
                count++;
                if (currentStudents <= 0) continue;
                long needC = (currentStudents + C - 1) / C;
                count += needC;
            }

            sw.WriteLine(count);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
