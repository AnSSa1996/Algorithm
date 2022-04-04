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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int A_Attack = inputs[0];
            int A_Sleep = inputs[1];
            int B_Attack = inputs[2];
            int B_Sleep = inputs[3];

            int[] p = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int i = 0; i < 3; i++)
            {
                int count = 0;
                int currentP = p[i];
                int Atemp = currentP % (A_Attack + A_Sleep) == 0 ? A_Attack + A_Sleep : currentP % (A_Attack + A_Sleep);
                int Btemp = currentP % (B_Attack + B_Sleep) == 0 ? B_Attack + B_Sleep : currentP % (B_Attack + B_Sleep);
                if (Atemp <= A_Attack) count++;
                if (Btemp <= B_Attack) count++;
                sw.WriteLine(count);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
