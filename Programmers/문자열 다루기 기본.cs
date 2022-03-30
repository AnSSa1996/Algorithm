public class Solution {
    public bool solution(string s) {
            int temp = 0;
            int length = s.Length;
            bool isNums = int.TryParse(s, out temp);
            bool answer = ((length == 4 || length == 6) && isNums);
        return answer;
    }
}