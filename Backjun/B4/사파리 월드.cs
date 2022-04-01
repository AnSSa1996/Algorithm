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

            List<long> inputList = Array.ConvertAll(sr.ReadLine().Split(), long.Parse).ToList();

            long results = Math.Abs(inputList[0] - inputList[1]);

            sw.WriteLine(results);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
