using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string[] str = sr.ReadLine().Split();
            string nums = str[0];
            int notation = int.Parse(str[1]);

            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int currentN = check(nums[i]);
                int result = currentN * (int)Math.Pow(notation, nums.Length - i - 1);
                count += result;
            }

            sw.WriteLine(count);

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        public static int check(char c)
        {
            if (c <= '9') return c - '0';
            else return (c - 'A' + 10);
        }
    }
}