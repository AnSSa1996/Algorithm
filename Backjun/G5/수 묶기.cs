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
            List<int> numList = new List<int>();
            for (int i = 0; i < N; i++) numList.Add(int.Parse(sr.ReadLine()));

            numList.Sort();
            bool reverse = true;
            int result = 0;
            int index = numList.Count - 1;
            while (index >= 0)
            {
                if (index == 0)
                {
                    result += numList[index];
                    break;
                }

                var left = numList[index - 1];
                var right = numList[index];

                if (reverse && left <= 0 && right <= 0)
                {
                    numList.Reverse();
                    reverse = false;
                    continue;
                }

                if (left < 0 && right <= 0)
                {
                    result += left * right;
                    numList.RemoveAt(index--);
                    numList.RemoveAt(index--);
                    continue;
                }

                if ((left < 0 && right > 0) || (left == 0 && right > 0) || left == 1 || right == 1)
                {
                    result += right;
                    numList.RemoveAt(index--);
                    continue;
                }

                result += left * right;
                numList.RemoveAt(index--);
                numList.RemoveAt(index--);
                continue;
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}