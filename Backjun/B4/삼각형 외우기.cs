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

            List<int> angleList = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                angleList.Add(int.Parse(sr.ReadLine()));
            }

            sw.WriteLine(CheckAngle(angleList));

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static string CheckAngle(List<int> angles)
        {
            if (angles.Sum() != 180)
                return "Error";
            else if (angles.GroupBy(x => x).Where(g => g.Count() == 3).Count() == 1)
            {
                return "Equilateral";
            }
            else if (angles.GroupBy(x => x).Where(g => g.Count() == 2).Count() == 1)
            {
                return "Isosceles";
            }
            else return "Scalene";
        }
    }
}
