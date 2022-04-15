using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int ax = inputs[0]; int ay = inputs[1]; int bx = inputs[2]; int by = inputs[3]; int cx = inputs[4]; int cy = inputs[5];

            if ((ax - bx) * (by - cy) == (bx - cx) * (ay - by)) sw.WriteLine("-1.0");
            else
            {
                List<double> lst = new List<double>();

                var ab_length = (ax - bx) * (ax - bx) + (ay - by) * (ay - by);
                var ac_length = (ax - cx) * (ax - cx) + (ay - cy) * (ay - cy);
                var bc_length = (bx - cx) * (bx - cx) + (by - cy) * (by - cy);

                lst.Add(ab_length);
                lst.Add(ac_length);
                lst.Add(bc_length);

                sw.WriteLine($"{(Math.Sqrt(lst.Max()) - Math.Sqrt(lst.Min())) * 2:f15}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
