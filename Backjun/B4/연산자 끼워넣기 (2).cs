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
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] oper = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int firstNum = nums[0];

            List<int> answerLst = new List<int>();

            DFS(1, firstNum);

            sw.WriteLine(answerLst.Max());
            sw.WriteLine(answerLst.Min());

            void DFS(int K, int answer)
            {
                if (K == N) { answerLst.Add(answer); return; }
                if (oper[0] > 0)
                {
                    oper[0]--;
                    DFS(K + 1, answer + nums[K]);
                    oper[0]++;
                }
                if (oper[1] > 0)
                {
                    oper[1]--;
                    DFS(K + 1, answer - nums[K]);
                    oper[1]++;
                }
                if (oper[2] > 0)
                {
                    oper[2]--;
                    DFS(K + 1, answer * nums[K]);
                    oper[2]++;
                }
                if (oper[3] > 0)
                {
                    oper[3]--;
                    DFS(K + 1, answer / nums[K]);
                    oper[3]++;
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
