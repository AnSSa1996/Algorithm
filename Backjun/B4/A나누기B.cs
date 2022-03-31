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

            decimal[] d = Array.ConvertAll(sr.ReadLine().Split(), decimal.Parse);
            decimal result = d[0] / d[1];

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

}
