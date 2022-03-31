using System;
using System.Collections.Generic;

public class Solution {
    public static Dictionary<string, Node> nodeDict = new Dictionary<string, Node>();
    public int[] solution(string[] enroll, string[] referral, string[] seller, int[] amount) {
            
            for (int i = 0; i < enroll.GetLength(0); i++)
            {
                nodeDict.Add(enroll[i], new Node(referral[i]));
            }

            for (int i = 0; i < seller.GetLength(0); i++)
            {
                int currentAmount = amount[i] * 100;
                string currentSeller = seller[i];

                DFS(currentSeller, currentAmount);
            }

            List<int> resultList = new List<int>();

            foreach(var items in nodeDict)
            {
                resultList.Add(items.Value.price);
            }

            int[] answer = resultList.ToArray();

        return answer;
    }
    
            public static void DFS(string name, int amount)
        {
            if (amount / 10 < 1)
            {
                nodeDict[name].price += amount;
                return;
            }

            int opponentAmount = amount / 10;
            int myAmount = amount - opponentAmount;
            nodeDict[name].price += myAmount;

            if (nodeDict[name].UpNode != "-")
                DFS(nodeDict[name].UpNode, opponentAmount);
        }
}


    public class Node
    {
        public string UpNode;
        public int price = 0;

        public Node(string upNode)
        {
            UpNode = upNode;
        }
    }