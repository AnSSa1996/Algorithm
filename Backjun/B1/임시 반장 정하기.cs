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

            List<int[]> students = new List<int[]>();

            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                students.Add(inputs);
            }

            //int[,] stuArray = new int[N + 1, N + 1];

            List<List<int>> stuLst = new List<List<int>>();
            for (int i = 0; i < N; i++) stuLst.Add(Enumerable.Repeat(0, N).ToList());


            for (int currentStudent = 0; currentStudent < N; currentStudent++)
            {
                int cnt = 0;
                for (int compareStudent = 0; compareStudent < N; compareStudent++)
                {
                    for (int g = 0; g < 5; g++)
                    {
                        if (currentStudent == compareStudent) continue;
                        if (students[currentStudent][g] == students[compareStudent][g])
                        {
                            stuLst[currentStudent][compareStudent] = 1;
                            stuLst[compareStudent][currentStudent] = 1;
                        }
                    }
                }
            }

            int[] count = new int[N];

            for (int i = 0; i < N; i++)
            {
                count[i] = stuLst[i].Count(x => x == 1);
            }

            sw.WriteLine(Array.IndexOf(count, count.Max()) + 1);


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}