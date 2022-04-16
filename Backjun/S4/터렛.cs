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

            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {

                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                int X1 = inputs[0]; int Y1 = inputs[1]; int R1 = inputs[2];
                int X2 = inputs[3]; int Y2 = inputs[4]; int R2 = inputs[5];

                double d = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));

                int result = 0;

                if (d == 0 && R1 == R2) result = -1; // 원이 완전히 겹칠 때
                else if (R2 - R1 == d || R1 - R2 == d) result = 1; // 내접
                else if (R1 + R2 == d) result = 1; //외접                
                else if (R1 > d + R2 || R2 > d + R1) result = 0; // 원을 포함할 떄
                else if (d < R1 + R2) result = 2; // 원이 두 곳 겹칠 때
                else if (d > R1 + R2) result = 0; // 원의 사이가 멀 때
                
                sw.WriteLine(result);
            }



            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
