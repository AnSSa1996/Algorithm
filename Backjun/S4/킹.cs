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

            string[] strs = sr.ReadLine().Split();
            int[,] board = new int[8, 8];

            int K_X = strs[0][0] - 'A';
            int K_Y = strs[0][1] - '1';

            int S_X = strs[1][0] - 'A';
            int S_Y = strs[1][1] - '1';

            int N = int.Parse(strs[2]);

            for (int i = 0; i < N; i++)
            {
                string str = sr.ReadLine();
                Tuple<int, int> move = Check(str);

                int moveY = move.Item1;
                int moveX = move.Item2;

                if (K_X + moveX >= 0 && K_X + moveX <= 7 && K_Y + moveY >= 0 && K_Y + moveY <= 7)
                {
                    if (K_X + moveX == S_X && K_Y + moveY == S_Y)
                    {
                        if (S_X + moveX >= 0 && S_X + moveX <= 7 && S_Y + moveY >= 0 && S_Y + moveY <= 7)
                        {
                            K_X += moveX; K_Y += moveY; S_X += moveX; S_Y += moveY;
                        }
                    }
                    else
                    {
                        K_X += moveX; K_Y += moveY;
                    }
                }
            }

            sw.WriteLine($"{(char)(K_X + 'A')}{K_Y + 1}");
            sw.WriteLine($"{(char)(S_X + 'A')}{S_Y + 1}");


            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static Tuple<int, int> Check(string str)
        {
            if (str == "R") return new Tuple<int, int>(0, 1);
            else if (str == "L") return new Tuple<int, int>(0, -1);
            else if (str == "B") return new Tuple<int, int>(-1, 0);
            else if (str == "T") return new Tuple<int, int>(1, 0);
            else if (str == "RT") return new Tuple<int, int>(1, 1);
            else if (str == "LT") return new Tuple<int, int>(1, -1);
            else if (str == "RB") return new Tuple<int, int>(-1, 1);
            else return new Tuple<int, int>(-1, -1);
        }
    }
}

