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

            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string str = sr.ReadLine();
                int left = 0; int right = str.Length - 1;
                bool check_Left = false;
                bool check_Right = false;
                while (left < right)
                {
                    if (str[left] == str[right])
                    {
                        left++; right--;
                        continue;
                    }
                    else
                    {
                        check_Left = Check(str, left + 1, right);
                        check_Right = Check(str, left, right - 1);

                        if (check_Left || check_Right) { sw.WriteLine(1); goto end; }
                        else { sw.WriteLine(2); goto end; }
                    }
                }

                sw.WriteLine(0);

            end:;
            }


            bool Check(string str, int left, int right)
            {
                while (left < right)
                {
                    if (str[left] == str[right])
                    {
                        left++; right--;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}