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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            Queue<int> q = new Queue<int>();
            Array.ForEach(inputs, x => q.Enqueue(x));

            List<int> lst = new List<int>();

            int[] nums = q.ToArray();
            lst.Add(1000 * nums[0] + 100 * nums[1] + 10 * nums[2] + nums[3]);
            for (int i = 1; i < 4; i++)
            {
                q.Enqueue(q.Dequeue());
                nums = q.ToArray();
                lst.Add(1000 * nums[0] + 100 * nums[1] + 10 * nums[2] + nums[3]);
            }

            int num = lst.Min();

            int cnt = 1;
            int init = 1111;
            while (true)
            {
                int[] currentNums = init.ToString().ToArray().Select(x => x - '0').ToArray();
                if (currentNums.Count(x => x == 0) >= 1) { init++; continue; }
                List<int> currentLst = new List<int>();
                currentLst.Add(1000 * currentNums[0] + 100 * currentNums[1] + 10 * currentNums[2] + currentNums[3]);

                Queue<int> currentQ = new Queue<int>();
                Array.ForEach(currentNums, x => currentQ.Enqueue(x));

                for (int i = 1; i < 4; i++)
                {
                    currentQ.Enqueue(currentQ.Dequeue());
                    currentNums = currentQ.ToArray();
                    currentLst.Add(1000 * currentNums[0] + 100 * currentNums[1] + 10 * currentNums[2] + currentNums[3]);
                }
                if (currentLst.Min() != init) { init++; continue; }
                if (currentLst.Min() == num) break;

                init++; cnt++;
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
