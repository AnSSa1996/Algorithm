using System;
using System.IO;
using System.Numerics;
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

            var inputUnicode = Array.ConvertAll(sr.ReadLine().Split(),int.Parse);

            int n1 = inputUnicode[0];
            int n2 = inputUnicode[1];
            int n12 = inputUnicode[2];

            int result = (n1 + 1)*(n2 + 1) / (n12 + 1) - 1;

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
