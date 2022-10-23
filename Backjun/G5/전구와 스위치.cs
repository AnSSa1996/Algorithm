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
            int[] UP = sr.ReadLine().Select(x => x - '0').ToArray();
            int[] DOWN = sr.ReadLine().Select(x => x - '0').ToArray();

            int[] First_Click = UP.ToArray();
            int[] First_Not_Click = UP.ToArray();

            First_Click[0] = First_Click[0] == 0 ? 1 : 0;
            First_Click[1] = First_Click[1] == 0 ? 1 : 0;

            int firstClickCount = int.MaxValue;
            int firstNotCount = int.MaxValue;
            bool FirstClickSolution()
            {
                int count = 1;
                for (int i = 1; i < N; i++)
                {
                    if (First_Click[i - 1] == DOWN[i - 1]) continue;
                    if (i < N - 1)
                    {
                        count++;
                        First_Click[i - 1] = First_Click[i - 1] == 0 ? 1 : 0;
                        First_Click[i] = First_Click[i] == 0 ? 1 : 0;
                        First_Click[i + 1] = First_Click[i + 1] == 0 ? 1 : 0;
                    }
                    else if (i == N - 1)
                    {
                        count++;
                        First_Click[i - 1] = First_Click[i - 1] == 0 ? 1 : 0;
                        First_Click[i] = First_Click[i] == 0 ? 1 : 0;
                    }
                }

                if (Enumerable.SequenceEqual(First_Click, DOWN))
                {
                    firstClickCount = count;
                    return true;
                }
                return false;
            }

            bool FirstNotClickSolution()
            {
                int count = 0;
                for (int i = 1; i < N; i++)
                {
                    if (First_Not_Click[i - 1] == DOWN[i - 1]) continue;
                    if (i < N - 1)
                    {
                        count++;
                        First_Not_Click[i - 1] = First_Not_Click[i - 1] == 0 ? 1 : 0;
                        First_Not_Click[i] = First_Not_Click[i] == 0 ? 1 : 0;
                        First_Not_Click[i + 1] = First_Not_Click[i + 1] == 0 ? 1 : 0;
                    }
                    else if (i == N - 1)
                    {
                        count++;
                        First_Not_Click[i - 1] = First_Not_Click[i - 1] == 0 ? 1 : 0;
                        First_Not_Click[i] = First_Not_Click[i] == 0 ? 1 : 0;
                    }
                }

                if (Enumerable.SequenceEqual(First_Not_Click, DOWN))
                {
                    firstNotCount = count;
                    return true;
                }
                return false;
            }

            bool check = FirstClickSolution();
            bool notCheck = FirstNotClickSolution();

            if (check == false && notCheck == false) sw.WriteLine(-1);
            else sw.WriteLine(Math.Min(firstClickCount, firstNotCount));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
