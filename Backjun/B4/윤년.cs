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

            int input = int.Parse(sr.ReadLine());
            int result = checkYoon(input);

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static int checkYoon(int year)
        {
            int result = 0;
            if (year % 4 == 0) result = 1;
            if (year % 100 == 0) result = 0;
            if (year % 400 == 0) result = 1;
            return result;
        }
    }

}
