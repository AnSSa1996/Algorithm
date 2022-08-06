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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int W = inputs[0]; int H = inputs[1];
            int N = int.Parse(sr.ReadLine());

            List<(int Dir, int Pos)> shops = new List<(int Dir, int Pos)>();

            for (int i = 0; i < N; i++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                shops.Add((inputs[0], inputs[1]));
            }

            inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int dir = inputs[0];
            int pos = inputs[1];

            int count = 0;
            for (int i = 0; i < N; i++)
            {
                var currentDir = shops[i].Dir;
                var currentPos = shops[i].Pos;

                int least = 0;
                if (dir == currentDir)
                {
                    least = Math.Abs(pos - currentPos);
                }
                else if (dir + currentDir == 3)
                {
                    var left = H + pos + currentPos;
                    var right = H + 2 * W - pos - currentPos;

                    least = Math.Min(left, right);
                }
                else if (dir + currentDir == 7)
                {
                    var left = W + pos + currentPos;
                    var right = W + 2 * H - pos - currentPos;

                    least = Math.Min(left, right);
                }

                // 북, 동
                else if (dir == 1 && currentDir == 4)
                {
                    least = W - pos + currentPos;
                }
                // 동, 남
                else if (dir == 4 && currentDir == 2)
                {
                    least = H - pos + W - currentPos;
                }
                // 남, 서
                else if (dir == 2 && currentDir == 3)
                {
                    least = pos + H - currentPos;
                }
                // 서, 북
                else if (dir == 3 && currentDir == 1)
                {
                    least = pos + currentPos;
                }
                // 북, 서
                else if (dir == 1 && currentDir == 3)
                {
                    least = pos + currentPos;
                }
                // 동, 북
                else if (dir == 4 && currentDir == 1)
                {
                    least = pos + W - currentPos;
                }
                // 남, 동
                else if (dir == 2 && currentDir == 4)
                {
                    least = W - pos + H - currentPos;
                }
                // 서, 남
                else if (dir == 3 && currentDir == 2)
                {
                    least = H - pos + currentPos;
                }

                count += least;
            }

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}