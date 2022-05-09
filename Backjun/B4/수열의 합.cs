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

            long[] inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

            long answer = inputs[0]; long minLength = inputs[1];

            long sum = 0;
            long num = -1;
            long length = 0;

            for (long i = minLength; i <= 100; i++)
            {
                sum = (i * i - i) / 2;
                if ((answer - sum) % i == 0 && (answer - sum) / i >= 0)
                {
                    num = (answer - sum) / i;
                    length = i;
                    break;
                }
            }

            if (num == -1) sw.WriteLine(-1);
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < length; i++)
                {
                    sb.Append($"{num + i} ");
                }
                sb.Remove(sb.Length - 1, 1);
                sw.WriteLine(sb);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
