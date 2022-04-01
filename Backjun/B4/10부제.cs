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


            int day = int.Parse(sr.ReadLine());
            List<int> carNums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();

            int results = carNums.Where(x => x == day).Count();

            sw.WriteLine(results);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
