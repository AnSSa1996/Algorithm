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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int N = inputs[0]; int B = inputs[1];
            int count = 0;
            string strN = Convert.ToString(N, 2);
            int stringCount = strN.Length;
            while (strN.Count(x => x == '1') > B)
            {
                int index = stringCount - strN.LastIndexOf('1');
                int plus = 1 << index - 1;
                count += plus;
                N += plus;
                strN = Convert.ToString(N, 2);
            }

            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
