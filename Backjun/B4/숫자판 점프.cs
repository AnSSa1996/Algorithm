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

            int[] dx = new int[4] { 1, 0, -1, 0 };
            int[] dy = new int[4] { 0, -1, 0, 1 };

            List<List<int>> board = new List<List<int>>();

            List<int[]> answerLst = new List<int[]>();
            int[] nums = new int[6];

            for (int i = 0; i < 5; i++)
            {
                List<int> lst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
                board.Add(lst);
            }

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    DFS(y, x, 0);
                }
            }
            void DFS(int y, int x, int K)
            {
                if (K == 6) { answerLst.Add(nums.ToArray()); return; }

                for (int i = 0; i < 4; i++)
                {
                    int nextY = y + dy[i];
                    int nextX = x + dx[i];
                    if (nextY < 0 || nextY >= 5 || nextX < 0 || nextX >= 5) continue;
                    nums[K] = board[nextY][nextX];
                    DFS(nextY, nextX, K + 1);
                }
            }

            answerLst = answerLst.Distinct(new ListOfIntComparer()).ToList();

            sw.WriteLine(answerLst.Count());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
    class ListOfIntComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] a, int[] b)
        {
            return
                a.SequenceEqual(b);
        }

        public int GetHashCode(int[] l)
        {
            unchecked
            {
                int hash = 19;
                foreach (var foo in l)
                {
                    hash = hash * 31 + foo.GetHashCode();
                }
                return hash;
            }
        }
    }
}
