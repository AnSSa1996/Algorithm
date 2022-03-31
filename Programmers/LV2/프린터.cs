using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[] priorities, int location) {
        
            List<SanghunClass> prioritiesList = new List<SanghunClass>();
            List<int> locationList = new List<int>();

            for (int i = 0; i < priorities.Length; i++)
            {
                prioritiesList.Add(new SanghunClass(i, priorities[i]));
            }

            while (prioritiesList.Count > 0)
            {
                int max = prioritiesList.Max(x => x.Priority);

                if (prioritiesList[0].Priority == max)
                {
                    locationList.Add(prioritiesList[0].Name);
                    prioritiesList.RemoveAt(0);
                }
                else
                {
                    var temp = prioritiesList[0];
                    prioritiesList.Add(temp);
                    prioritiesList.RemoveAt(0);
                }
            }


            int result = locationList.IndexOf(location) + 1;
        return result;
    }
}

 class SanghunClass
    {
        public int Name;
        public int Priority;
        public SanghunClass(int name, int prioirty)
        {
            Name = name; Priority = prioirty;
        }
    }