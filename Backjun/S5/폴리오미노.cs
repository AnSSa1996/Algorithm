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
            StringBuilder sb = new StringBuilder();

            char[] charArray = sr.ReadLine().ToArray();

            int cnt = 0;
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == 'X') cnt++;
                else
                {
                    if (cnt % 2 == 1)
                    {
                        sb.Clear();
                        sb.Append(-1);
                        break;
                    }
                    else
                    {
                        int A = cnt / 4;
                        cnt %= 4;
                        int B = cnt / 2;
                        sb.Append(string.Concat(Enumerable.Repeat("AAAA", A)));
                        sb.Append(string.Concat(Enumerable.Repeat("BB", B)));
                        sb.Append(".");
                        cnt = 0;
                    }
                }

                if (i == charArray.Length - 1)
                {
                    if (cnt % 2 == 1)
                    {
                        sb.Clear();
                        sb.Append(-1);
                        break;
                    }
                    else
                    {
                        int A = cnt / 4;
                        cnt %= 4;
                        int B = cnt / 2;
                        sb.Append(string.Concat(Enumerable.Repeat("AAAA", A)));
                        sb.Append(string.Concat(Enumerable.Repeat("BB", B)));
                    }
                }
            }

            sw.WriteLine(sb);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
