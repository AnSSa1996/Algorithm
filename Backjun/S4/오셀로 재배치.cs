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

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int length = int.Parse(sr.ReadLine());
                var up = sr.ReadLine().ToArray();
                var down = sr.ReadLine().ToArray();

                List<char> upLst = new List<char>();
                List<char> downLst = new List<char>();

                for (int j = 0; j < length; j++)
                {
                    if (up[j] != down[j])
                    {
                        upLst.Add(up[j]);
                        downLst.Add(down[j]);
                    }
                }

                upLst.Sort(); downLst.Sort();

                float cnt = 0;
                for (int j = 0; j < upLst.Count(); j++)
                {
                    if (upLst[j] == downLst[j]) cnt += 0.5f;
                    else cnt += 1f;
                }

                sw.WriteLine((int)cnt);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
