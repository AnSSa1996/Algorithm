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
            int one = inputs[0]; int two = inputs[1]; int three = inputs[2];
            int[] times = new int[101];

            for (int i = 0; i < 3; i++)
            {
                int[] t = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int start = t[0]; int end = t[1];

                for (int time = start; time < end; time++) times[time]++;
            }

            int count = 0;
            for (int i = 1; i < 101; i++)
            {
                if (times[i] == 0) continue;
                if (times[i] == 1) count += one;
                else if (times[i] == 2) count += two * 2;
                else count += three * 3;
            }

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}