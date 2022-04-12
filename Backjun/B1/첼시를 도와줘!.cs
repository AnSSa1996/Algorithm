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
            StringBuilder resultSb = new StringBuilder();

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int count = int.Parse(sr.ReadLine());
                List<Tuple<int, string>> players = new List<Tuple<int, string>>();

                for (int j = 0; j < count; j++)
                {
                    string[] str = sr.ReadLine().Split();
                    int cost = int.Parse(str[0]);
                    string name = str[1];
                    players.Add(new Tuple<int, string>(cost, name));
                }

                var sortedLst = players.OrderByDescending(x => x.Item1);
                sw.WriteLine(sortedLst.First().Item2);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}