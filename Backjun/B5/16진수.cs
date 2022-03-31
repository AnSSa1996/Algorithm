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

            string input = sr.ReadLine();
            string decimalString = Convert.ToInt32(input, 16).ToString();

            sw.WriteLine(decimalString);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
