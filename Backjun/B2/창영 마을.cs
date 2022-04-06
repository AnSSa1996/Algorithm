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

            bool[] balls = new bool[3] { true, false, false };

            char[] charArray = sr.ReadLine().ToArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                bool temp;
                if (charArray[i] == 'A')
                {
                    temp = balls[0];
                    balls[0] = balls[1];
                    balls[1] = temp;
                }
                else if (charArray[i] == 'B')
                {
                    temp = balls[1];
                    balls[1] = balls[2];
                    balls[2] = temp;
                }
                else
                {
                    temp = balls[2];
                    balls[2] = balls[0];
                    balls[0] = temp;
                }
            }

            for (int i = 1; i < 4; i++) if (balls[i - 1]) sw.WriteLine(i);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}