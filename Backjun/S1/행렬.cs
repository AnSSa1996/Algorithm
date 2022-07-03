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
            int Y = inputs[0]; int X = inputs[1];
            List<List<int>> board = new List<List<int>>();
            List<List<int>> answer = new List<List<int>>();
            for (int i = 0; i < Y; i++) { board.Add(sr.ReadLine().Select(x => x - '0').ToList()); }
            for (int i = 0; i < Y; i++) { answer.Add(sr.ReadLine().Select(x => x - '0').ToList()); }

            int count = 0;

            for (int y = 0; y < Y - 2; y++)
            {
                for (int x = 0; x < X - 2; x++)
                {
                    if (board[y][x] != answer[y][x])
                    {
                        Reverse(y, x);
                        count++;
                    }
                }
            }

            var checkAnswer = Check();

            if (checkAnswer) sw.WriteLine(count);
            else sw.WriteLine(-1);



            bool Check()
            {
                var check = true;
                for (int y = 0; y < Y; y++)
                {
                    for (int x = 0; x < X; x++)
                    {
                        if (board[y][x] != answer[y][x]) check = false;
                    }
                }
                return check;
            }


            void Reverse(int startY, int startX)
            {
                if (Y < 3 || X < 3) return;
                for (int y = startY; y < startY + 3; y++)
                {
                    for (int x = startX; x < startX + 3; x++)
                    {
                        if (board[y][x] == 1) board[y][x] = 0;
                        else board[y][x] = 1;
                    }
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}