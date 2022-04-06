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

            string[] str = sr.ReadLine().Split();

            string left = str[0];
            string right = str[1];

            int leftCount = 0;
            int rightCount = 0;

            foreach (char c in left)
            {
                if (right.Contains(c))
                {
                    leftCount = left.IndexOf(c);
                    rightCount = right.IndexOf(c);
                    break;
                }
            }

            for (int i = 0; i < right.Length; i++)
            {
                if (i == rightCount)
                {
                    sw.WriteLine(left);
                    continue;
                }
                StringBuilder tempSb = new StringBuilder();
                tempSb.Append(string.Concat(Enumerable.Repeat(".", leftCount)));
                tempSb.Append(right[i]);
                tempSb.Append(string.Concat(Enumerable.Repeat(".", left.Length - leftCount - 1)));
                sw.WriteLine(tempSb);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}