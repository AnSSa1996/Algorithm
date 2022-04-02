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

            int result = 0;

            int meat = int.Parse(sr.ReadLine());
            int target = int.Parse(sr.ReadLine());
            int iceTime = int.Parse(sr.ReadLine());
            int meltTime = int.Parse(sr.ReadLine());
            int hotTime = int.Parse(sr.ReadLine());

            if (meat < 0)
            {
                result += iceTime * -meat;
                meat = 0;
            }
            if (meat == 0)
            {
                result += meltTime;
            }
            if (meat < target)
            {
                result += hotTime * (target - meat);
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}