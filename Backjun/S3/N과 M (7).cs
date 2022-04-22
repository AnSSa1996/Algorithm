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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0];
            int K = inputs[1];

            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            Array.Sort(nums);
            int[] numArray = new int[K]; bool[] check = new bool[N];

            DFS(0, K, N, 0, nums, numArray, check);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static void DFS(int num, int K, int N, int currentNum, int[] nums, int[] numArray, bool[] check)
        {
            if (num == K) Console.WriteLine(string.Join(" ", numArray));
            else
            {
                for (int i = 0; i < N; i++)
                {
                    if (check[i] == false)
                    {
                        numArray[num] = nums[i];
                        currentNum = nums[i];
                        DFS(num + 1, K, N, currentNum, nums, numArray, check);
                        check[i] = true;
                    }
                    check[i] = false;
                }
            }
        }
    }
}