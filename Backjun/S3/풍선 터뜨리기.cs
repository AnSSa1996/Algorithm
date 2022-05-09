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

            int N = int.Parse(sr.ReadLine());

            int[] numbers = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            List<Tuple<int, int>> lst = new List<Tuple<int, int>>();
            for (int i = 1; i <= N; i++) { lst.Add(new Tuple<int, int>(i, numbers[i - 1])); }

            int index = 0;
            int count = N;
            List<int> answer = new List<int>();
            while (true)
            {
                int temp = index;
                answer.Add(lst[temp].Item1);
                if (lst[temp].Item2 > 0) index = index + lst[temp].Item2 - 1;
                else index = index + lst[temp].Item2;
                lst.RemoveAt(temp);
                count--;
                if (count == 0) break;
                index %= count;
                if (index < 0) index += count;
            }

            sw.WriteLine(string.Join(" ", answer));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
