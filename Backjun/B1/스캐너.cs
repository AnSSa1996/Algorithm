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
            int X = inputs[1];
            int mY = inputs[2];
            int mX = inputs[3];

            List<char[]> lst = new List<char[]>();

            for (int i = 0; i < Y; i++) lst.Add(sr.ReadLine().ToArray());

            List<string> newList = new List<string>();

            for (int y = 0; y < Y; y++)
            {
                StringBuilder tempSb = new StringBuilder();
                for (int x = 0; x < X; x++)
                {
                    for (int repeat = 0; repeat < mX; repeat++)
                    {
                        tempSb.Append(lst[y][x]);
                    }
                }
                newList.Add(tempSb.ToString());
            }

            for (int y = 0; y < Y; y++)
            {
                for (int repeat = 0; repeat < mY; repeat++)
                {
                    sw.WriteLine(newList[y]);
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}