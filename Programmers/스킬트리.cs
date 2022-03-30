using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(string skill, string[] skill_trees) {
            
        int count = 0;

            foreach (string s in skill_trees)
            {
                count += SanghunSolution(skill, s);
            }
        return count;
    }
    
      public static int SanghunSolution(string skill, string currentSkill)
        {
            List<char> previousSkill = skill.ToList();

            for (int i = 0; i < currentSkill.Length; i++)
            {
                if(previousSkill.Contains(currentSkill[i]))
                {
                    if(currentSkill[i] == previousSkill[0])
                    {
                        previousSkill.RemoveAt(0);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return 1;
        }
}