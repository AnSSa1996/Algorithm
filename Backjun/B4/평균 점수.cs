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

            int total = 0;
            for (int i = 0; i < 5; i++)
            {
                int score = int.Parse(sr.ReadLine());
                if (score < 40) score = 40;
                total += score;
            }

            int result = total / 5;

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

}
