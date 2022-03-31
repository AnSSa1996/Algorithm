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

            string inputString = sr.ReadLine();

            int remain = 0;
            foreach (var c in inputString)
            {
                int intC = c - '0';
                remain = (remain * 10 + intC) % 20000303;
            }

            sw.WriteLine(remain);
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
