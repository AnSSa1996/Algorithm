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
            int left = inputs[0]; int right = inputs[1];

            int five = Count_Five(left) - Count_Five(left - right) - Count_Five(right);
            int two = Count_Two(left) - Count_Two(left - right) - Count_Two(right);

            sw.WriteLine(Math.Min(five, two));


            int Count_Five(int n)
            {
                int cnt = 0;
                while (n > 0)
                {
                    cnt += n / 5; n /= 5;
                }
                return cnt;
            }

            int Count_Two(int n)
            {
                int cnt = 0;
                while (n > 0)
                {
                    cnt += n / 2; n /= 2;
                }
                return cnt;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}