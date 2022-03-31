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
            string result;

            if (input >= 90) result = "A";
            else if (input >= 80) result = "B";
            else if (input >= 70) result = "C";
            else if (input >= 60) result = "D";
            else result = "F";

            sw.WriteLine(result);


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

}
