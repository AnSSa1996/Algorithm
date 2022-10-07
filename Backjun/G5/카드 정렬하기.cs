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
            int N = inputs[0]; int K = inputs[1];

            List<int> board = new List<int>(Array.ConvertAll(sr.ReadLine().Split(), int.Parse));

            Rotate(board);

            void Rotate(List<int> lst)
            {
                int count = lst.Count();
                var temp = lst[count - 1];
                for (int i = count - 1; i > 0; i--)
                {
                    lst[i] = lst[i - 1];
                }
                lst[0] = temp;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}