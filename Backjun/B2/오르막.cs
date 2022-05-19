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

            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            bool nDescending = true;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    nDescending = false;
                    break;
                }
            }

            if (nDescending) sw.WriteLine("Good");
            else sw.WriteLine("Bad");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
