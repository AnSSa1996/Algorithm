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

            string str = sr.ReadLine();
            string checkS = sr.ReadLine();

            var checkBool = KMP(str, checkS);
            if (checkBool) sw.WriteLine(1);
            else sw.WriteLine(0);

            int[] Table(string checkString)
            {
                int size = checkString.Length;
                int[] table = new int[size];

                int j = 0;
                for (int i = 1; i < size; i++)
                {
                    while (j > 0 && checkString[i] != checkString[j])
                    {
                        j = table[j - 1];
                    }

                    if (checkString[i] == checkString[j])
                    {
                        table[i] = ++j;
                    }
                }

                return table;
            }

            bool KMP(string parent, string check)
            {
                var table = Table(str);
                int parentSize = parent.Length;
                int checkSize = check.Length;

                int j = 0;

                for (int i = 0; i < parentSize; i++)
                {
                    while (j > 0 && parent[i] != check[j])
                    {
                        j = table[j - 1];
                    }

                    if (parent[i] == check[j])
                    {
                        if (j == checkSize - 1) return true;
                        else
                        {
                            j++;
                        }
                    }
                }

                return false;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}