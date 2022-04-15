using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

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
                int num = int.Parse(sr.ReadLine());
                bool isCheck = false;

                for (int j = 2; j < 65; j++)
                {
                    List<int> lstReverse = ConvertNum(num, j);
                    List<int> lstClone = lstReverse.ToList();
                    lstReverse.Reverse();
                    if (lstReverse.SequenceEqual(lstClone))
                    {
                        isCheck = true;
                        break;
                    }
                }

                if (isCheck) sw.WriteLine(1);
                else sw.WriteLine(0);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static List<int> ConvertNum(int num, int bit)
        {
            List<int> lst = new List<int>();
            while (true)
            {
                if (num == 0) break;
                lst.Add(num % bit);
                num /= bit;
            }
            return lst;
        }
    }
}
