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

            int A = inputs[0];
            int P = inputs[1];

            List<int> lst = new List<int>() { A };

            while (true)
            {
                var last = lst.Last().ToString().Select(x => x - '0').ToArray();
                int temp = 0;
                Array.ForEach(last, a => temp += (int)Math.Pow(a, P));
                if (lst.Contains(temp))
                {
                    int index = lst.IndexOf(temp);
                    lst = lst.GetRange(0, index);
                    break;
                }
                else lst.Add(temp);
            }

            sw.WriteLine(lst.Count());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
