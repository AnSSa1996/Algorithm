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
            int[] people = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int result = inputs[0] * inputs[1];

            List<int> answer = new List<int>();
            for (int i = 0; i < 5; i++) answer.Add(people[i] - result);
            sw.WriteLine(string.Join(" ", answer));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
