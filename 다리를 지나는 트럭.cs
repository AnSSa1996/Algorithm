using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int bridge_length, int weight, int[] truck_weights) {
                    Queue<int> trucks = new Queue<int>(truck_weights);
            List<Truck> bridge = new List<Truck>();

            int currentWeight = 0;
            int Count = 0;

            while (trucks.Count > 0 || bridge.Count > 0)
            {
                Count++;

                for (int i = bridge.Count - 1; i >= 0; i--)
                {
                    bridge[i].Pos++;

                    if (bridge[i].Pos == bridge_length)
                    {
                        currentWeight -= bridge[i].Weight;
                        bridge.RemoveAt(i);
                    }
                }

                if (trucks.Count > 0)
                {
                    int temp = trucks.Peek();

                    if (currentWeight + temp <= weight)
                    {
                        currentWeight += trucks.Dequeue();

                        Truck temp_truck = new Truck(temp, 0);

                        bridge.Add(temp_truck);
                    }
                }
            }
        return Count;
    }
}

    class Truck
    {
        public int Weight;
        public int Pos;

        public Truck(int weight, int pos)
        {
            Weight = weight;
            Pos = pos;
        }
    }