using System;
using System.Text;

public class Solution {
    public int solution(int n) {
        StringBuilder sb = new StringBuilder();

            int remainder = 0;
            while (n > 0)
            {
                remainder = n % 3;
                n = n / 3;
                sb.Append(remainder);
            }

            int pow = sb.Length;
            int sum = 0;
            for (int i = 0; i < sb.Length; i++)
            {
                int num = int.Parse(sb[i].ToString());
                sum += num * Pow(3, pow - i - 1);
            }
        return sum;
    }
    
    public static int Pow(int a, int b)
        {
            int num = 1;
            for(int i = 0; i<b; i++)
            {
                num = num * a;
            }
            return num;
        }
}