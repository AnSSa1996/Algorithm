public class Solution {
    public int[] solution(int n, int m) {
            int gcdInt = gcd(n, m);
            int lcmInt = (n * m) / gcdInt;

            int[] answer = new int[] { gcdInt, lcmInt };
        return answer;
    }
    
    public static int gcd(int n, int m)
        {
            if (m == 0) return n;
            else return gcd(m, n % m);
        }
}