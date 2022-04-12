using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int Y = inputs[0];
            int X = inputs[0];

            List<char[]> strList = new List<char[]>();

            for (int i = 0; i < Y; i++)
            {
                StringBuilder tempSb = new StringBuilder();
                string str = sr.ReadLine();

                tempSb.Append(str);
                tempSb.Append(new string(str.Reverse().ToArray()));

                strList.Add(tempSb.ToString().ToArray());
            }

            for (int i = Y - 1; i >= 0; i--)
            {
                strList.Add((char[])strList[i].Clone());
            } 

            int[] pos = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int y = pos[0] - 1;
            int x = pos[1] - 1;

            if (strList[y][x] == '#') strList[y][x] = '.';
            else strList[y][x] = '#';

            for (int i = 0; i < Y * 2; i++)
            {
                sw.WriteLine(new string(strList[i]));
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}