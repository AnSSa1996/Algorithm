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
            int womans = inputs[0];
            int mans = inputs[1];
            int intern = inputs[2];

            int maxTeam = Math.Min(womans / 2, mans);
            int teamTotal = maxTeam * 2 + mans;
            int remain = womans + mans - teamTotal;

            int result = 0;
            if (remain >= intern) result = maxTeam;
            else result = Math.Min((womans + mans - intern) / 3, maxTeam);

            sw.Write(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}