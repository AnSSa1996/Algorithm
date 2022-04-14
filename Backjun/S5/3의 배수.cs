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

            char[] charArray = sr.ReadLine().ToArray();

            int cnt = 0;
            string check = "NO";
            while (true)
            {
                if (charArray.Length == 1)
                {
                    if (charArray[0] % 3 == 0) check = "YES";
                    break;
                }
                charArray = charArray.Sum(x => x - '0').ToString().ToArray();
                cnt++;
            }

            sw.WriteLine(cnt);
            sw.WriteLine(check);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
