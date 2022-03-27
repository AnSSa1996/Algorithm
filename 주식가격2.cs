using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersLv1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = { 1, 2, 3, 2, 3 };

            Stack<int> stack = new Stack<int>();
            int length = prices.Length;
            List<int> answer = new List<int>(prices);

            for (int i = 0; i < length; i++)
            {
                while (stack.Count != 0 && prices[stack.Peek()] > prices[i])
                {
                    int top = stack.Pop();
                    answer[top] = i - top;
                }
                stack.Push(i);
            }

            while (stack.Count != 0)
            {
                int top = stack.Pop();
                answer[top] = length - 1 - top;
            }
        }
    }
}
