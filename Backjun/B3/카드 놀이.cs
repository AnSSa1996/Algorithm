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

            int A_WinCost = 0;
            int B_WinCont = 0;
            string lastWin = "D";

            for (int i = 0; i < 10; i++)
            {
                if (A_Array[i] > B_Array[i])
                {
                    A_WinCost += 3;
                    lastWin = "A";
                }
                else if (A_Array[i] < B_Array[i])
                {
                    B_WinCont += 3;
                    lastWin = "B";
                }
                else
                {
                    A_WinCost += 1;
                    B_WinCont += 1;
                }
            }

            sw.WriteLine($"{A_WinCost} {B_WinCont}");
            if (A_WinCost > B_WinCont) sw.WriteLine("A");
            else if (A_WinCost < B_WinCont) sw.WriteLine("B");
            else sw.WriteLine(lastWin);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
