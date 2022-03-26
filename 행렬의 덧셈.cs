public class Solution {
    public int[,] solution(int[,] arr1, int[,] arr2) {
        
            int column = arr1.GetLength(0);
            int row = arr1.GetLength(1);

            int[,] answer = new int[column, row];

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    int value = arr1[i, j] + arr2[i, j];
                    answer[i, j] = value;
                }
            }
        return answer;
    }
}