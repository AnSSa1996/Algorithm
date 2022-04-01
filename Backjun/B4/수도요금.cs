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

            int Xcompany = 0;
            int Ycompany = 0;

            int XcompanyCost = int.Parse(sr.ReadLine());
            int YcompanyDefaultCost = int.Parse(sr.ReadLine());
            int YcompanyDefaultL = int.Parse(sr.ReadLine());
            int YcompanyAddCost = int.Parse(sr.ReadLine());
            int usedL = int.Parse(sr.ReadLine());

            Xcompany = XcompanyCost * usedL;

            if(usedL <= YcompanyDefaultL)
            {
                Ycompany = YcompanyDefaultCost;
            }
            else
            {
                Ycompany = YcompanyDefaultCost + (usedL - YcompanyDefaultL) * YcompanyAddCost;
            }

            int result = Math.Min(Xcompany, Ycompany);

            sw.Write(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
