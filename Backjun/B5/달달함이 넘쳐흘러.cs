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

            int[] firstInputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] secondInputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            sw.WriteLine($"{secondInputs[0] - firstInputs[2]} {secondInputs[1] / firstInputs[1]} {secondInputs[2] - firstInputs[0]}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
