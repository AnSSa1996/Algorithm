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

            int[] timeInput = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int elapsedTime = int.Parse(sr.ReadLine());

            int Totalminute = timeInput[0] * 60 + timeInput[1] + elapsedTime;

            int hour = (Totalminute / 60 >= 24) ? (Totalminute / 60) - 24 : (Totalminute / 60);
            int minute = Totalminute % 60;

            sw.WriteLine($"{hour} {minute}");

            sw.Flush();
            sw.Close();
        }
    }

}
