using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] numbers, int target) {
            Queue<QueueClass> q = new Queue<QueueClass>();

            q.Enqueue(new QueueClass(0, numbers[0]));
            q.Enqueue(new QueueClass(0, -numbers[0]));


            int Count = 0;

            while (q.Count > 0)
            {
                QueueClass currentQ = q.Dequeue();
                int currentIndex = currentQ.CurrentIndex;
                int result = currentQ.Result;

                if (currentIndex == numbers.Length - 1)
                {
                    if (result == target)
                    {
                        Count += 1;
                    }
                    continue;
                }

                q.Enqueue(new QueueClass(currentIndex + 1, result + numbers[currentIndex + 1]));
                q.Enqueue(new QueueClass(currentIndex + 1, result - numbers[currentIndex + 1]));
            }
        return Count;
    }
}

public class QueueClass
    {
        public int CurrentIndex;
        public int Result;

        public QueueClass(int currentIndex, int result)
        {
            CurrentIndex = currentIndex;
            Result = result;
        }
    }