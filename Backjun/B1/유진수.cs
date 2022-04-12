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

            string str = sr.ReadLine();

            bool check = false;
            for (int i = 1; i < str.Length; i++)
            {
                int leftTotal = 1;
                int rightTotal = 1;

                for (int left = 0; left < i; left++) leftTotal *= str[left] - '0';
                for (int right = i; right < str.Length; right++) rightTotal *= str[right] - '0';

                if (leftTotal == rightTotal)
                {
                    check = true;
                    break;
                }
            }

            if (check) sw.WriteLine("YES");
            else sw.WriteLine("NO");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}