using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            bool sampleCheck = true;
            bool testCheck = true;

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            for (int i = 0; i < inputs[0]; i++)
            {
                int[] samples = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                if (samples[0] != samples[1]) { sampleCheck = false; break; }
            }

            for (int i = 0; i < inputs[1]; i++)
            {
                int[] tests = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                if (tests[0] != tests[1]) { testCheck = false; break; }
            }

            if (sampleCheck && testCheck) sw.WriteLine("Accepted");
            else if (!sampleCheck) sw.WriteLine("Wrong Answer");
            else if (sampleCheck && !testCheck) sw.WriteLine("Why Wrong!!!");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}