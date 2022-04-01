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

            int results = 0;
            int cost = inputList[0] * inputList[1];
            int money = inputList[2];

            if (cost > money) results = cost - money;

            sw.WriteLine(results);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
