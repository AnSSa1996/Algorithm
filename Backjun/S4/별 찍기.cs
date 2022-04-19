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

            int N = int.Parse(sr.ReadLine());
            char[,] charArray = new char[4 * N - 3, 4 * N - 3];

            for (int i = 0; i < (4 * N - 3); i++) for (int j = 0; j < (4 * N - 3); j++) charArray[i, j] = ' ';

            Recursive(charArray, 1, N);

            for (int i = 0; i < (4 * N - 3); i++)
            {
                StringBuilder tempSb = new StringBuilder();
                for (int j = 0; j < (4 * N - 3); j++)
                {
                    tempSb.Append(charArray[i, j]);
                }
                sw.WriteLine(tempSb);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
        public static void Recursive(char[,] charArray, int num, int N)
        {
            if (num == 1) charArray[2 * (N - 1), 2 * (N - 1)] = '*';
            else
            {
                int sp = 2 * (N - num);
                for (int i = 0; i < (num * 4 - 3); i++) charArray[sp, sp + i] = '*';
                for (int i = 1; i <= (num * 4 - 5); i++)
                {
                    charArray[sp + i, sp] = '*';
                    charArray[sp + i, sp + 4 * (num - 1)] = '*';
                }
                for (int i = 0; i < (num * 4 - 3); i++) charArray[sp + 4 * (num - 1), sp + i] = '*';
            }
            if (num == N) return;
            Recursive(charArray, num + 1, N);
        }
    }
}

