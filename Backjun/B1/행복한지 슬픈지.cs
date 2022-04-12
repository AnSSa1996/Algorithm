using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string str = sr.ReadLine();

            int happy = Regex.Matches(str, ":-\\)").Count;
            int sad = Regex.Matches(str, ":-\\(").Count;

            if (happy + sad == 0) sw.WriteLine("none");
            else if (happy > sad) sw.WriteLine("happy");
            else if (happy < sad) sw.WriteLine("sad");
            else if (happy == sad) sw.WriteLine("unsure");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}