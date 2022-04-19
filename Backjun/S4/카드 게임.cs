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

            List<Tuple<char, int>> lst = new List<Tuple<char, int>>();

            for (int i = 0; i < 5; i++)
            {
                string[] strs = sr.ReadLine().Split();
                char color = strs[0][0];
                int number = int.Parse(strs[1]);

                lst.Add(new Tuple<char, int>(color, number));
            }

            var groupColor = lst.GroupBy(x => x.Item1).OrderByDescending(g => g.Count());
            var groupNumber = lst.OrderByDescending(a => a.Item2).GroupBy(x => x.Item2).OrderByDescending(g => g.Count());

            bool numSuccess = true;
            if (groupNumber.Count() == 5)
            {
                for (int i = 0; i < 4; i++)
                    if (groupNumber.ElementAt(i).ElementAt(0).Item2 - 1 != groupNumber.ElementAt(i + 1).ElementAt(0).Item2) numSuccess = false;
            }
            else numSuccess = false;


            int total = 0;
            if (groupColor.Count() == 1 && numSuccess) total = 900 + groupNumber.ElementAt(0).ElementAt(0).Item2;
            else if (groupNumber.ElementAt(0).Count() == 4) total = 800 + groupNumber.ElementAt(0).ElementAt(0).Item2;
            else if (groupNumber.ElementAt(0).Count() == 3 && groupNumber.Count() == 2)
                total = 700 + groupNumber.ElementAt(0).ElementAt(0).Item2 * 10 + groupNumber.ElementAt(1).ElementAt(0).Item2;
            else if (groupColor.Count() == 1) total = 600 + lst.OrderByDescending(x => x.Item2).First().Item2;
            else if (numSuccess) total = 500 + groupNumber.ElementAt(0).ElementAt(0).Item2;
            else if (groupNumber.ElementAt(0).Count() == 3) total = 400 + groupNumber.ElementAt(0).ElementAt(0).Item2;
            else if (groupNumber.Count() == 3 && groupNumber.ElementAt(0).Count() == 2 && groupNumber.ElementAt(1).Count() == 2)
                total = 300 + groupNumber.ElementAt(0).ElementAt(0).Item2 * 10 + groupNumber.ElementAt(1).ElementAt(0).Item2;
            else if (groupNumber.Count() == 4) total = 200 + groupNumber.ElementAt(0).ElementAt(0).Item2;
            else total = 100 + lst.OrderByDescending(x => x.Item2).First().Item2;

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

