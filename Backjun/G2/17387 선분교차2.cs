using System;
using System.IO;
using System.Linq;

namespace Backj
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sw = new StreamWriter(Console.OpenStandardOutput());
            var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            var x1 = inputs[0];
            var y1 = inputs[1];
            var x2 = inputs[2];
            var y2 = inputs[3];
            
            inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            var x3 = inputs[0];
            var y3 = inputs[1];
            var x4 = inputs[2];
            var y4 = inputs[3];
            
            if (IsCross(x1, y1, x2, y2, x3, y3, x4, y4))
            {
                sw.WriteLine(1);
            }
            else
            {
                sw.WriteLine(0);
            }

            sw.Close();
            sr.Close();
        }
        
        public static void Swap(ref long a, ref long b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
        
        public static bool IsCross(long x1, long y1, long x2, long y2, long x3, long y3, long x4, long y4)
        {
            var first = CCW(x1, y1, x2, y2, x3, y3) * CCW(x1, y1, x2, y2, x4, y4);
            var second = CCW(x3, y3, x4, y4, x1, y1) * CCW(x3, y3, x4, y4, x2, y2);
            if (first == 0 && second == 0)
            {
                if (x1 > x2)
                {
                    Swap(ref x1, ref x2);
                }
                if (y1 > y2)
                {
                    Swap(ref y1, ref y2);
                }
                if (x3 > x4)
                {
                    Swap(ref x3, ref x4);
                }
                if (y3 > y4)
                {
                    Swap(ref y3, ref y4);
                }
                return x1 <= x4 && x3 <= x2 && y1 <= y4 && y3 <= y2;
            }
            return first <= 0 && second <= 0;
        }
        
        public static int CCW(long x1, long y1, long x2, long y2, long x3, long y3)
        {
            var result = (x2 - x1) * (y3 - y1) - (y2 - y1) * (x3 - x1);
            if (result > 0)
            {
                return 1;
            }
            else if (result < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}