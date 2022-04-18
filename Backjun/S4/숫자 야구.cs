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

            List<int> lst = new List<int>();

            for (int i = 123; i <= 999; i++)
            {
                char[] temp = i.ToString().ToArray();
                if (temp.Contains('0')) continue;
                else if (temp[0] == temp[1] || temp[1] == temp[2] || temp[0] == temp[2]) continue;
                lst.Add(i);
            }

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                char[] question = inputs[0].ToString().ToArray();
                int S = inputs[1];
                int B = inputs[2];

                for (int num = 0; num < lst.Count; num++)
                {
                    char[] answer = lst[num].ToString().ToArray();
                    int b = 0;
                    int s = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (question.Contains(answer[j])) b++;
                        if (question[j] == answer[j]) { b--; s++; }
                    }

                    if (!(S == s && B == b)) { lst.RemoveAt(num); num--; }
                }
            }

            sw.WriteLine(lst.Count());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
