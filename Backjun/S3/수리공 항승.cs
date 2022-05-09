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

            int count = inputs[0]; int T = inputs[1];

            int[] pipes = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            Array.Sort(pipes);

            int cnt = 1;
            int currentP = pipes[0] + T;

            for (int i = 1; i < count; i++)
            {
                if (currentP > pipes[i]) continue;
                else { currentP = pipes[i] + T; cnt++; }
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
