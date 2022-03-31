public class Solution {
    public int solution(int num) {

            long numLong = (long)num;
            int Count = 0;
            while (!(numLong == 1))
            {
                numLong = SanghunSoltion(numLong);
                if (Count > 500)
                {
                    Count = -1;
                    break;
                }
                Count++;
            }
        return Count;
    }
    
        public static long SanghunSoltion(long n)
        {
            if (n % 2 == 0)
            {
                return n / 2;
            }
            else
            {
                return n * 3 + 1;
            }
        }
}