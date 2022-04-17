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
            List<int> lst = Enumerable.Range(1, inputs[0]).ToList();
            List<int> sortedLst = new List<int>();
            int plus = inputs[1];
            int index = 0;
            while (true)
            {
                if (lst.Count == 0) break;
                index += plus - 1;
                while (index >= lst.Count()) index -= lst.Count;
                int item = lst[index];
                lst.RemoveAt(index);
                sortedLst.Add(item);
            }

            sw.WriteLine($"<{string.Join(", ", sortedLst)}>");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
