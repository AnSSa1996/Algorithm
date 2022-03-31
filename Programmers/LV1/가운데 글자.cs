using System.Text;

public class Solution {
    public string solution(string s) {

            StringBuilder sb = new StringBuilder();

            int stringLength = s.Length;
            int num = stringLength / 2;

            if (stringLength % 2 == 1)
            {
                sb.Append(s[num]);
            }
            else
            {
                sb.Append(s[num - 1]);
                sb.Append(s[num]);
            }

            string answer = sb.ToString();
        return answer;
    }
}