using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            for (int i = 1; i <= N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int HP = (inputs[0] + inputs[4]) < 1 ? 1 : inputs[0] + inputs[4];
                int MP = (inputs[1] + inputs[5]) < 1 ? 1 : inputs[1] + inputs[5];
                int Attack = inputs[2] + inputs[6] < 0 ? 0 : inputs[2] + inputs[6];
                int Defense = inputs[3] + inputs[7];

                int result = HP + MP * 5 + Attack * 2 + Defense * 2;
                sw.WriteLine(result);
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
