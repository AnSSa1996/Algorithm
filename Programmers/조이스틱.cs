using System;

public class Solution {
    public int solution(string name) {
           
            int count = 0;
            int move = name.Length - 1;

            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] < 'N')
                {
                    count += name[i] - 'A';
                }
                else
                {
                    count += 'Z' - name[i] + 1;
                }

                int index = i + 1;

                while(index < name.Length && name[index] == 'A')
                {
                    index++;
                }

                move = Math.Min(move, i * 2 + name.Length - index);
                move = Math.Min(move, (name.Length - index) * 2 + i);
            }

            int answer = count + move;
        return answer;
    }
}