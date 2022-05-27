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
            StringBuilder sb = new StringBuilder();

            string[] inputs = sr.ReadLine().Split();

            string left = inputs[0];
            string right = inputs[1];

            int leftLength = left.Length;
            int rightLength = right.Length;

            int maxLength = Math.Max(leftLength, rightLength);

            int leftIndex = leftLength;
            int rightIndex = rightLength;

            int li = 0;
            int ri = 0;
            for (int i = 0; i < maxLength; i++)
            {
                int sum = 0;
                if (leftIndex < maxLength) { leftIndex++; }
                else sum += left[li++] - '0';

                if (rightIndex < maxLength) { rightIndex++; }
                else sum += right[ri++] - '0';

                sb.Append(sum.ToString());
            }

            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
