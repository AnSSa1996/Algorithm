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

            sb.Append("       _.-;;-._\n");
            sb.Append("'-..-'|   ||   |\n");
            sb.Append("'-..-'|_.-;;-._|\n");
            sb.Append("'-..-'|   ||   |\n");
            sb.Append("'-..-'|_.-''-._|");

            sw.WriteLine(sb.ToString());
            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
