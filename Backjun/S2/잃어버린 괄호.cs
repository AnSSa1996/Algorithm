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

            string[] str = sr.ReadLine().Split('-');

            List<int> lst = new List<int>();
            foreach (string s in str)
            {
                int[] nums = Array.ConvertAll(s.Split('+'), int.Parse);
                lst.Add(nums.Sum());
            }

            int total = lst[0];
            for (int i = 1; i < lst.Count(); i++) total -= lst[i];

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}