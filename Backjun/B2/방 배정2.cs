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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0];
            int K = inputs[1];

            int[] students = new int[5] { 0, 0, 0, 0, 0 };

            for (int i = 0; i < N; i++)
            {
                int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int gender = input[0];
                int grade = input[1];
                int index = checkIndex(gender, grade);
                students[index]++;
            }

            int count = students.Sum(x => (x + K - 1) / K);
            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static int checkIndex(int gender, int grade)
        {
            if (grade == 1 || grade == 2) return 0;
            else if ((grade == 3 || grade == 4) && gender == 0) return 1;
            else if ((grade == 3 || grade == 4) && gender == 1) return 2;
            else if ((grade == 5 || grade == 6) && gender == 0) return 3;
            else return 4;
        }
    }
}