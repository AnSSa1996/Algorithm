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

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(sr.ReadLine());
                string bit = Convert.ToString(num, 2);
                bit = new string(bit.ToCharArray().Reverse().ToArray());
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < bit.Length; j++) if (bit[j] == '1') sb.Append($"{j} ");
                sb.Remove(sb.Length - 1, 1);
                sw.WriteLine(sb);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
