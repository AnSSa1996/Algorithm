using System;
using System.Linq;
using System.Text;

public class Solution {
    public int solution(int n, int k) {
        string kToString = SanghunConvert(n, k);
            string[] strings = kToString.Split('0');

            int Count = 0;
            foreach (var s in strings)
            {
                if (s.Length == 0)
                    continue;
                long nums = long.Parse(s);
                if (isPrime(nums))
                    Count++;
            }
        return Count;
    }
    
      public static string SanghunConvert(int n, int k)
        {
            StringBuilder sb = new StringBuilder();

            int quotient = n;
            int remainder = k;
            while (true)
            {
                if (quotient == 0)
                    break;
                remainder = quotient % k;
                quotient = quotient / k;
                sb.Append(remainder);
            }
            var returnString = sb.ToString().Reverse().ToArray();
            return new string(returnString);
        }

        public static bool isPrime(long n)
        {
            if (n == 1) return false;
            for (long i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
}