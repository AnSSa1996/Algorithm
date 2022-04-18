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

            int K = int.Parse(sr.ReadLine());
            List<int> allLst = new List<int>();

            int max_Height = 0;
            int H_index = 0;

            int max_Widht = 0;
            int W_index = 0;

            for (int i = 0; i < 6; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int direction = inputs[0];
                int length = inputs[1];
                allLst.Add(length);

                if (direction <= 2) // 가로
                {
                    if (max_Widht <= length)
                    {
                        max_Widht = length;
                        W_index = i;
                    }
                }
                else // 세로
                {
                    if (max_Height <= length)
                    {
                        max_Height = length;
                        H_index = i;
                    }
                }
            }

            List<int> lst = new List<int>();

            lst.Add(allLst[(H_index + 1) % 6]);
            lst.Add(allLst[(H_index - 1) < 0 ? 5 : H_index - 1]);
            lst.Add(allLst[(W_index + 1) % 6]);
            lst.Add(allLst[(W_index - 1) < 0 ? 5 : W_index - 1]);

            int emptySquare = 1;

            for (int i = 0; i < 6; i++)
            {
                if (lst.Contains(allLst[i])) continue;
                else emptySquare *= allLst[i];
            }

            sw.WriteLine((max_Height * max_Widht - emptySquare) * K);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
