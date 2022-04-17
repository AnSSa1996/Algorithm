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
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StreamReader sr = new StreamReader(Console.OpenStandardInput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] choices = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            List<int> nums = Enumerable.Range(1, inputs[0]).ToList();
            int cnt = 0;
            for (int i = 0; i < inputs[1]; i++)
            {
                int choice = choices[i];
                cnt = solution(nums, choice, cnt);
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static int solution(List<int> nums, int choice, int cnt)
        {
            int index = nums.IndexOf(choice);

            if (index < (nums.Count + 1) / 2) left(index);
            else right(index);

            nums.RemoveAt(0);
            return cnt;

            void left(int N)
            {
                for (int i = 0; i < N; i++)
                {
                    int num = nums[0];
                    nums.RemoveAt(0);
                    nums.Add(num);
                    cnt++;
                }
            }

            void right(int N)
            {
                for (int i = 0; i < nums.Count - N; i++)
                {
                    int num = nums[nums.Count - 1];
                    nums.RemoveAt(nums.Count - 1);
                    nums.Insert(0, num);
                    cnt++;
                }
            }
        }
    }
}
