using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] A_Array = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] B_Array = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int AWin = 0;
            int BWin = 0;

            for (int i = 0; i < 10; i++)
            {
                if (A_Array[i] > B_Array[i]) AWin++;
                else if (A_Array[i] < B_Array[i]) BWin++;
            }

            if (AWin > BWin) sw.WriteLine("A");
            else if (AWin < BWin) sw.WriteLine("B");
            else sw.WriteLine("D");

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
