using System;
using System.IO;
using System.Text;

namespace ProgrammersLv1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int fixedCost = input[0];
            int productCost = input[1];
            int earn = input[2];

            int realEarn = earn - productCost;

            int result = -1;
            if (realEarn > 0)
            {
                result = fixedCost / realEarn + 1;
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

}
