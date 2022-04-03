using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string score = sr.ReadLine();

            float result = 0;
            switch (score)
            {
                case "A+":
                    result = 4.3f;
                    break;
                case "A0":
                    result = 4.0f;
                    break;
                case "A-":
                    result = 3.7f;
                    break;
                case "B+":
                    result = 3.3f;
                    break;
                case "B0":
                    result = 3.0f;
                    break;
                case "B-":
                    result = 2.7f;
                    break;
                case "C+":
                    result = 2.3f;
                    break;
                case "C0":
                    result = 2.0f;
                    break;
                case "C-":
                    result = 1.7f;
                    break;
                case "D+":
                    result = 1.3f;
                    break;
                case "D0":
                    result = 1.0f;
                    break;
                case "D-":
                    result = 0.7f;
                    break;
            }

            sw.WriteLine($"{result:0.0}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
