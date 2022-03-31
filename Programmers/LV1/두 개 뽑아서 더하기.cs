using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] numbers) {
            List<int> numbersList = numbers.ToList();
            List<List<int>> combinationList = GetCombinationList(numbersList, 2);

            List<int> result = new List<int>();

            foreach(var nums in combinationList)
            {
                int sum = nums.Sum();
                if (!(result.Contains(sum)))
                {
                    result.Add(sum);
                }
            }

            result.Sort();
            int[] answer = result.ToArray();
        return answer;
    }
    
    public static void SelectItem<T>(List<T> itemList, bool[] selectionArray, List<List<T>> resultList, int selectionCount, int firstItemIndex)
        {
            if (selectionCount == 0)
            {
                List<T> selectionList = new List<T>();
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (selectionArray[i])
                    {
                        selectionList.Add(itemList[i]);
                    }
                }
                resultList.Add(selectionList);
            }
            else
            {
                for (int i = firstItemIndex; i < itemList.Count; i++)
                {
                    selectionArray[i] = true;
                    SelectItem(itemList, selectionArray, resultList, selectionCount - 1, i + 1);
                    selectionArray[i] = false;
                }
            }
        }

        public static List<List<T>> GetCombinationList<T>(List<T> itemList, int selectionCount)
        {
            bool[] selectionArray = new bool[itemList.Count];
            List<List<T>> resultList = new List<List<T>>();
            SelectItem<T>(itemList, selectionArray, resultList, selectionCount, 0); return resultList;
        }
}