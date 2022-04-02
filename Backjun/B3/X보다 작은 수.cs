using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            int[] FirstInputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] SecondInputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            for (int i = 0; i < FirstInputs[0]; i++)
            {
                if (SecondInputs[i] < FirstInputs[1])
                    sb.Append($"{SecondInputs[i]} ");
            }

            sb.Remove(sb.Length - 1, 1);

            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
