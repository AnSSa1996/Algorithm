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

            int x = int.Parse(sr.ReadLine());
            int y = int.Parse(sr.ReadLine());

            int result = 0;
            if (x > 0 && y > 0) result = 1;
            else if (x < 0 && y > 0) result = 2;
            else if (x < 0 && y < 0) result = 3;
            else result = 4;

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

}
