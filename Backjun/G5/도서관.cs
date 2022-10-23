using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            int N = inputs[0]; int M = inputs[1];
            List<int> minusLst = new List<int>();
            List<int> plusLst = new List<int>();

            minusLst.Add(0);
            plusLst.Add(0);

            inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int i = 0; i < N; i++)
            {
                if (inputs[i] < 0) minusLst.Add(inputs[i]);
                else plusLst.Add(inputs[i]);
            }
            int result = 0;

            plusLst.Sort();
            minusLst.Sort((a, b) => b - a);

            if (-minusLst.Last() < plusLst.Last())
            {
                result += plusLst.Last();
                RemoveLst(ref plusLst, M);
            }
            else
            {
                result -= minusLst.Last();
                RemoveLst(ref minusLst, M);
            }

            while (plusLst.Count() > 0)
            {
                result += plusLst.Last() * 2;
                RemoveLst(ref plusLst, M);
            }

            while (minusLst.Count() > 0)
            {
                result -= minusLst.Last() * 2;
                RemoveLst(ref minusLst, M);
            }

            void RemoveLst(ref List<int> lst, int Count)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (lst.Count() == 0) return;
                    lst.RemoveAt(lst.Count() - 1);
                }
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
