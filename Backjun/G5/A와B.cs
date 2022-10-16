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

            string current = sr.ReadLine();
            List<char> answer = sr.ReadLine().ToList();
            bool check = false;
            while (true)
            {
                if (answer.Count() == current.Count())
                {
                    if (current == new string(answer.ToArray()))
                        check = true;
                    break;
                }

                if (answer.Last() == 'A')
                {
                    answer.RemoveAt(answer.Count() - 1);
                }
                else
                {
                    answer.RemoveAt(answer.Count() - 1);
                    answer.Reverse();
                }
            }

            if (check) sw.WriteLine(1);
            else sw.WriteLine(0);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
