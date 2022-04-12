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
                string[] str = sr.ReadLine().Split();
                string firstStr = str[0];
                string secondStr = str[1];
                List<char> firstStrLst = firstStr.ToList();
                List<char> secondStrLst = secondStr.ToList();

                bool isAnagram = true;

                for (int j = 0; j < firstStrLst.Count(); j++)
                {
                    char c = firstStrLst[j];
                    if (secondStrLst.Contains(c))
                    {
                        secondStrLst.Remove(c);
                        firstStrLst.Remove(c);
                        j--;
                    }
                    else
                    {
                        isAnagram = false;
                        break;
                    }
                }

                if (firstStrLst.Count() != 0 || secondStrLst.Count() != 0)
                {
                    isAnagram = false;
                }

                if (isAnagram) sw.WriteLine($"{firstStr} & {secondStr} are anagrams.");
                else sw.WriteLine($"{firstStr} & {secondStr} are NOT anagrams.");
            }


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}