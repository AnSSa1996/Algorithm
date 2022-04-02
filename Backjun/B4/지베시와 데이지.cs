using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string result = null;

            int[] bessie = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] daisy = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] target = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int bessieTime = Math.Max(Math.Abs(target[1] - bessie[1]), Math.Abs(target[0] - bessie[0]));
            int daisyTime = Math.Abs(target[0] - daisy[0]) + Math.Abs(target[1] - daisy[1]);

            if (bessieTime < daisyTime) result = "bessie";
            else if (bessieTime == daisyTime) result = "tie";
            else result = "daisy";

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
