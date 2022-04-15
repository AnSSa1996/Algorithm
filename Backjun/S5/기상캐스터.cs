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

            int rows = inputs[0];
            int columns = inputs[1];

            for (int i = 0; i < rows; i++)
            {
                char[] charArray = sr.ReadLine().ToArray();
                int index = -1;

                List<int> resultLst = new List<int>();
                for (int j = 0; j < columns; j++)
                {
                    if (charArray[j] == 'c')
                    {
                        index = 0;
                        resultLst.Add(index);
                    }
                    else
                    {
                        if (index == -1) resultLst.Add(-1);
                        else { index++; resultLst.Add(index); }
                    }
                }

                sw.WriteLine(string.Join(" ", resultLst));
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
