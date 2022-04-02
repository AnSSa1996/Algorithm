using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            for (int i = 0; i < 3; i++)
            {

                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                string result = "E";
                switch (inputs.Sum())
                {
                    case 3:
                        result = "A";
                        break;
                    case 2:
                        result = "B";
                        break;
                    case 1:
                        result = "C";
                        break;
                    case 0:
                        result = "D";
                        break;
                }
                sw.WriteLine(result);
            }
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
