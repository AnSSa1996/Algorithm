using System.Text;

public class Solution {
    public string solution(string s, int n) {
        StringBuilder sb = new StringBuilder();

            foreach (char character in s)
            {
                int characterNum = ((int)character);
                int newCharNum = 0;
                if (characterNum >= 97 && character <= 122)
                {
                    newCharNum = characterNum + n;
                    if (newCharNum >= 123)
                    {
                        newCharNum -= 26;
                    }
                    sb.Append((char)newCharNum);
                    continue;
                }
                else if (characterNum >= 65 && character <= 90)
                {
                    newCharNum = characterNum + n;
                    if (newCharNum >= 91)
                    {
                        newCharNum -= 26;
                    }
                    sb.Append((char)newCharNum);
                    continue;
                }
                sb.Append(character);
            }

            string answer = sb.ToString();
        return answer;
    }
}