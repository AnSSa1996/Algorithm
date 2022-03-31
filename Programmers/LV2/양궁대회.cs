using System;

public class Solution {
    
        public static int[] apeach;
        public static int[] lion = new int[11];

        public static int[] answer = new int[11];
        public static int remainedArrows = 0;
        public static int maxNum = 0;
        
        public static int LastIndex = 0;
    
    public int[] solution(int n, int[] info) {
        
            apeach = info;

            int apechPoint = 0;

            int index = 0;
            foreach (int i in info)
            {
                if (i != 0)
                    apechPoint += 10 - index;
                index++;
            }

            SanhungBFS(n, 0, apechPoint, 0);

            if (remainedArrows > 0)
            {
                answer[10] += remainedArrows;
            }

         
            if (maxNum == 0)
            {
                int[] answer = new int[1] { -1 };
                return answer;
            }
        return answer;
    }
    
    
    
        public static void SanhungBFS(int arrowNum, int index, int apechPoint, int lionPoint)
        {
            if (index >= 11 || arrowNum <= 0)
            {
                return;
            }

            if (arrowNum > apeach[index])
            {
                int tempApechPoint = apechPoint;
                if (apeach[index] > 0)
                    tempApechPoint = apechPoint - (10 - index);
                int tempLionPoint = lionPoint + (10 - index);
                int tempArrowNum = arrowNum - (apeach[index] + 1);
                lion[index] += apeach[index] + 1;
                if ((maxNum <= tempLionPoint - tempApechPoint))
                {   
                    if (LastIndex < index)
                    {
                        LastIndex = index;
                    }
                    if(maxNum == tempLionPoint - tempApechPoint)
                    {
                        if (LastIndex <= index)
                        {
                            Array.Copy(lion, answer, 10);
                            LastIndex = index;
                        }
                    }
                    else
                    {
                        maxNum = tempLionPoint - tempApechPoint;
                        remainedArrows = tempArrowNum;
                        Array.Copy(lion, answer, 10);
                    }
                }
                SanhungBFS(tempArrowNum, index + 1, tempApechPoint, tempLionPoint);
                lion[index] = 0;
            }

            SanhungBFS(arrowNum, index + 1, apechPoint, lionPoint);
        }
}