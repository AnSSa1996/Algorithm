using System.Collections.Generic;

public class Solution {
    public static List<int> months = new List<int> { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    public static List<string> days = new List<string> { "FRI", "SAT", "SUN", "MON", "TUE", "WED", "THU" };
    
    public string solution(int a, int b) {
        
        for (int i = 0; i < a - 1; i++)
            {
                b += months[i];
            }
            b = b - 1;
            int day = b % 7;

        string answer = days[day];
        return answer;
    }
}