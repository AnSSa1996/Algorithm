using System.Linq;

public class Solution {
    public static bool[] EratosBool = Enumerable.Repeat(true, 1000000).ToArray<bool>();
    public int solution(int n) {
        
        Eratos(n);
        int answer = 0;

            for (int i = 2; i <= n; i++)
            {
                if (EratosBool[i])
                    answer++;
            }
        return answer;
    }
    
    
        public static void Eratos(int n)
        {
            EratosBool[0] = false;
            EratosBool[1] = false;

            for (int i = 2; i * i < n; i++)
            {
                if (EratosBool[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        EratosBool[j] = false;
                    }
                }
            }
        }
}