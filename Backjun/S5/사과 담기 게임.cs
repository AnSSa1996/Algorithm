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
            int M = inputs[1];

            int left = 1;
            int right = M;

            int count = int.Parse(sr.ReadLine());
            int cnt = 0;
            for (int i = 0; i < count; i++)
            {
                int apple = int.Parse(sr.ReadLine());
                if (apple >= left && apple <= right) continue;
                else
                {
                    if (apple < left)
                    {
                        int move = left - apple;
                        cnt += move;
                        left -= move;
                        right -= move;
                    }
                    else if (apple > right)
                    {
                        int move = apple - right;
                        cnt += move;
                        left += move;
                        right += move;
                    }
                }
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
