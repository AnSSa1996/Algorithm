using System;

public class Solution {
    public int solution(int[] numbers) {
                    int Sum = 45;

            foreach (int num in numbers)
            {
                Sum -= num;
            }
        return Sum;
    }
}