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


            for (int i = 1000; i < 10000; i++)
            {
                int sum10 = i.ToString().ToArray().Sum(x => x - '0');
                int sum12 = convertBitSum(i, 12);
                int sum16 = convertBitSum(i, 16);

                if (sum10 == sum12 && sum12 == sum16)
                {
                    sw.WriteLine(i);
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static int convertBitSum(int num, int ToNum)
        {
            int total = 0;
            while (true)
            {
                int c = num % ToNum;
                num /= ToNum;
                total += c;

                if (num < ToNum)
                {
                    total += num;
                    break;
                }
            }

            return total;
        }
    }
}