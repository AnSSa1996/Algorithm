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

            int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            string result;

            if (input[0] > input[1]) result = ">";
            else if (input[0] < input[1]) result = "<";
            else result = "==";

            sw.WriteLine(result);


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

}
