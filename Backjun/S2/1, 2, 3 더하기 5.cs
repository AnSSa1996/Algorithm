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

            int T = int.Parse(sr.ReadLine());
            List<Tuple<long, long, long>> lst = new List<Tuple<long, long, long>>();
            lst.Add(new Tuple<long, long, long>(0, 0, 1));
            lst.Add(new Tuple<long, long, long>(0, 1, 0));
            lst.Add(new Tuple<long, long, long>(1, 1, 1));

            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(sr.ReadLine());
                Dp(N);
                sw.WriteLine((lst[N - 1].Item1 + lst[N - 1].Item2 + lst[N - 1].Item3) % 1000000009);
            }

            void Dp(int N)
            {
                int start = lst.Count();
                for (int i = start; i < N; i++)
                {
                    long one = 0; long two = 0; long three = 0;

                    three += lst[i - 3].Item2;
                    three += lst[i - 3].Item3;

                    two += lst[i - 2].Item1;
                    two += lst[i - 2].Item3;

                    one += lst[i - 1].Item1;
                    one += lst[i - 1].Item2;

                    lst.Add(new Tuple<long, long, long>(three % 1000000009, two % 1000000009, one % 1000000009));
                }
            }


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}