using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            List<int> inputList = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
            int needTime = int.Parse(sr.ReadLine());

            int totalTime = inputList[0] * 3600 + inputList[1] * 60 + inputList[2] + needTime;

            int hour = (totalTime / 3600 > 23) ? (totalTime / 3600) % 24 : (totalTime / 3600);
            totalTime = totalTime % 3600;
            int minute = (totalTime / 60);
            totalTime = totalTime % 60;
            int second = totalTime;

            sw.WriteLine($"{hour} {minute} {second}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
