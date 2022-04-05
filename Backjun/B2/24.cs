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

            int[] currentTimes = Array.ConvertAll(sr.ReadLine().Split(':'), int.Parse);
            int[] startTimes = Array.ConvertAll(sr.ReadLine().Split(':'), int.Parse);

            int CT_Second = currentTimes[0] * 3600 + currentTimes[1] * 60 + currentTimes[2];
            int ST_Second = startTimes[0] * 3600 + startTimes[1] * 60 + startTimes[2];

            int RT_Second = ST_Second - CT_Second >= 0 ?
                ST_Second - CT_Second :
                86400 + ST_Second - CT_Second;

            int h = RT_Second / 3600;
            RT_Second %= 3600;
            int m = RT_Second / 60;
            RT_Second %= 60;
            int s = RT_Second;

            sw.WriteLine($"{h:00}:{m:00}:{s:00}");

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
