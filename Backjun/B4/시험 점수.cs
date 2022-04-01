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

            List<int> min = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
            List<int> man = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();

            int results = Math.Max(min.Sum(), man.Sum());

            sw.WriteLine(results);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
