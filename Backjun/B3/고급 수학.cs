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
            StringBuilder resultSb = new StringBuilder();

            int N = int.Parse(sr.ReadLine());
            for (int index = 1; index <= N; index++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                Array.Sort(inputs);

                int a = inputs[0];
                int b = inputs[1];
                int c = inputs[2];

                resultSb.AppendLine($"Scenario #{index}:");

                if (a * a + b * b == c * c) resultSb.AppendLine("yes");
                else resultSb.AppendLine("no");
                resultSb.AppendLine();
            }

            resultSb.Remove(resultSb.Length - 1, 1);

            sw.Write(resultSb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
