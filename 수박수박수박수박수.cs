using System.Linq;
using System.Text;

public class Solution {
    public string solution(int n) {
            StringBuilder sb = new StringBuilder();

            int index = 0;
            while (index < n)
            {
                if (index % 2 == 0)
                    sb.Append("수");
                else
                    sb.Append("박");
                index++;
            }
            string answer = sb.ToString();
        return answer;
    }
}