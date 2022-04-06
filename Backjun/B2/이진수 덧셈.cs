using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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

            string[] str = sr.ReadLine().Split();

            char[] left = str[0].Reverse().ToArray();
            char[] right = str[1].Reverse().ToArray();

            int length = Math.Max(left.Length, right.Length);

            int tempN = 0;

            for (int i = 0; i < length; i++)
            {
                int leftN = 0;
                int rightN = 0;

                if (i >= left.Length) leftN = 0;
                else leftN = left[i] - '0';

                if (i >= right.Length) rightN = 0;
                else rightN = right[i] - '0';

                int sum = leftN + rightN + tempN;
                int num = 0;
                if (sum == 0)
                {
                    num = 0; tempN = 0;
                }
                else if (sum == 1)
                {
                    num = 1;
                    tempN = 0;
                }
                else if (sum == 2)
                {
                    num = 0;
                    tempN = 1;
                }
                else if (sum == 3)
                {
                    num = 1;
                    tempN = 1;
                }
                sb.Append(num);
                if (i == length - 1 && tempN == 1)
                {
                    sb.Append(tempN);
                }
            }

            List<char> curentBit = sb.ToString().Reverse().ToList();

            while (curentBit.Count() > 1)
            {
                if (curentBit[0] == '0') curentBit.RemoveAt(0);
                else break;
            }
            sw.WriteLine(new string(curentBit.ToArray()));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}