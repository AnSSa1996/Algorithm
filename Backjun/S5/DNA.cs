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

            StringBuilder result = new StringBuilder();
            char[] dna = new char[4] { 'A', 'C', 'G', 'T' };

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int N = inputs[0];
            int length = inputs[1];

            List<string> lst = new List<string>();
            List<int[]> indexLst = new List<int[]>();

            for (int i = 0; i < length; i++) indexLst.Add(new int[4]);

            for (int i = 0; i < N; i++)
            {
                string str = sr.ReadLine();
                lst.Add(str);

                for (int j = 0; j < length; j++)
                {
                    int index = check(str[j]);
                    indexLst[j][index]++;
                }
            }

            for (int i = 0; i < length; i++)
            {
                int index = Array.FindIndex(indexLst[i], l => l == indexLst[i].Max());
                result.Append(dna[index]);
            }

            string resultStr = result.ToString();

            int total = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (resultStr[j] != lst[i][j]) total++;
                }
            }

            sw.WriteLine(resultStr);
            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static int check(char c)
        {
            if (c == 'A') return 0;
            else if (c == 'C') return 1;
            else if (c == 'G') return 2;
            else return 3;
        }
    }
}
