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

            int[] playerAInputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] playerBInputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int A = (playerAInputs[1] + playerBInputs[0] - 1) / playerBInputs[0];
            int B = (playerBInputs[1] + playerAInputs[0] - 1) / playerAInputs[0];

            if (A > B) sw.WriteLine("PLAYER A");
            else if (A < B) sw.WriteLine("PLAYER B");
            else sw.WriteLine("DRAW");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}