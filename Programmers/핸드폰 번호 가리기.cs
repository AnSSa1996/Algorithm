using System.Text;

public class Solution {
    public string solution(string phone_number) {
            StringBuilder sb = new StringBuilder();

            int phoneStartLength = phone_number.Length - 5;

            for (int i = 0; i < phone_number.Length; i++)
            {
                if (phoneStartLength < i)
                {
                    sb.Append(phone_number[i]);
                }
                else
                {
                    sb.Append("*");
                }
            }

            string answer = sb.ToString();
        return answer;
    }
}