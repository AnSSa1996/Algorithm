using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    public static bool[] EratosBool = Enumerable.Repeat(true, 3001).ToArray<bool>();
    public int solution(int[] nums)
    {
        List<int> numsList = nums.ToList<int>();
            Eratos();

            List<List<int>> combinationList = new List<List<int>>();
            combinationList = GetCombinationList(numsList, 3);
            List<int> sumList = new List<int>();
            foreach (var combinationNums in combinationList)
            {
                sumList.Add(combinationNums.Sum());
            }

            int i = 0;

            foreach (int checkNum in sumList)
            {
                if (EratosBool[checkNum] == true)
                {
                    i++;
                }
            }

        return i;
    }
    
    
        public static void Eratos()
        {
            EratosBool[0] = false;
            EratosBool[1] = false;

            for (int i = 2; i * i < 3000; i++)
            {
                if (EratosBool[i])
                {
                    for (int j = i * i; j <= 3000; j += i)
                    {
                        EratosBool[j] = false;
                    }
                }
            }
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