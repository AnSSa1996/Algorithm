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

            int[] board = new int[1200];

            int currentNum = 1;
            for (int i = 1; i <= 1000;)
            {
                int repeat = currentNum;
                for (int j = 1; j <= repeat; j++)
                {
                    board[i++] = currentNum;
                }
                currentNum++;
            }

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int start = inputs[0];
            int end = inputs[1];

            int total = 0;
            for (int i = start; i <= end; i++) total += board[i];

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}