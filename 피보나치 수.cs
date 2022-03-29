public class Solution {
    public static long[] Dp;
    public long solution(int n) {
            
            Dp = new long[n+1];

            Dp[0] = 0;
            Dp[1] = 1;
            Dp[2] = 2;

            Fibo(n + 1);
            long answer = Dp[n] % 1234567;
        return answer;
    }
    
        public static void Fibo(int n)
        {
            for (int i = 2; i < n; i++)
            {
                Dp[i] = (Dp[i - 1] % 1234567 + Dp[i - 2] % 1234567);
            }
        }
}