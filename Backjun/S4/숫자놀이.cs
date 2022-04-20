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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int start = inputs[0];
            int end = inputs[1];

            int cnt = 0;

            List<Tuple<int, List<string>>> lst = new List<Tuple<int, List<string>>>();
            for (int i = start; i <= end; i++)
            {
                var num = i.ToString().ToArray();
                List<string> temp = new List<string>();
                for (int j = 0; j < num.Length; j++)
                {
                    string str = Check(num[j]);
                    temp.Add(str);
                }
                lst.Add(new Tuple<int, List<string>>(i, temp));
            }

            var sortedLst = lst.OrderBy(x => string.Join(" ", x.Item2))
                .ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= sortedLst.Count(); i++)
            {
                if (i % 10 != 0) sb.Append($"{sortedLst[i - 1].Item1} ");
                else sb.AppendLine($"{sortedLst[i - 1].Item1}");
            }

            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static string Check(char c)
        {
            if (c == '0') return "zero";
            else if (c == '1') return "one";
            else if (c == '2') return "two";
            else if (c == '3') return "three";
            else if (c == '4') return "four";
            else if (c == '5') return "five";
            else if (c == '6') return "six";
            else if (c == '7') return "seven";
            else if (c == '8') return "eight";
            else return "nine";
        }
    }
}
