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

            double total = 0;
            double grade = 0;

            for (int i = 0; i < N; i++)
            {
                string[] strs = sr.ReadLine().Split();

                double score = double.Parse(strs[1]);
                string g = strs[2];

                total += score;
                grade += Check(g) * score;
            }

            sw.WriteLine($"{Math.Round(grade / total, 2):f2}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static double Check(string grade)
        {
            switch (grade)
            {
                case "A+":
                    return 4.3;
                case "A0":
                    return 4.0;
                case "A-":
                    return 3.7;
                case "B+":
                    return 3.3;
                case "B0":
                    return 3.0;
                case "B-":
                    return 2.7;
                case "C+":
                    return 2.3;
                case "C0":
                    return 2.0;
                case "C-":
                    return 1.7;
                case "D+":
                    return 1.3;
                case "D0":
                    return 1.0;
                case "D-":
                    return 0.7;
                default:
                    return 0.0;
            }
        }
    }
}