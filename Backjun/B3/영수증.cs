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
            StringBuilder sb = new StringBuilder();

            int bookSum = int.Parse(sr.ReadLine());
            int totalBookSum = 0;

            for (int i = 0; i < 9; i++) totalBookSum += int.Parse(sr.ReadLine());

            sw.WriteLine(bookSum - totalBookSum);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
