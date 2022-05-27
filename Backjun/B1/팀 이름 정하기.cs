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

            string love = sr.ReadLine();
            int L = love.Count(x => x == 'L');
            int O = love.Count(x => x == 'O');
            int V = love.Count(x => x == 'V');
            int E = love.Count(x => x == 'E');

            int maxCount = 0; int index = 0;

            int N = int.Parse(sr.ReadLine());
            List<string> strLst = new List<string>();
            for (int i = 0; i < N; i++) { strLst.Add(sr.ReadLine()); }
            strLst.Sort();

            for (int i = 0; i < N; i++)
            {
                int sumL = strLst[i].Count(x => x == 'L') + L;
                int sumO = strLst[i].Count(x => x == 'O') + O;
                int sumV = strLst[i].Count(x => x == 'V') + V;
                int sumE = strLst[i].Count(x => x == 'E') + E;
                int total = ((sumL + sumO) * (sumL + sumV) * (sumL + sumE) *
                    (sumO + sumV) * (sumO + sumE) * (sumV + sumE)) % 100;

                if (total > maxCount)
                {
                    maxCount = total;
                    index = i;
                }
            }

            sw.WriteLine(strLst[index]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
