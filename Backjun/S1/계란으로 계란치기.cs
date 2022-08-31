using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            int N = int.Parse(sr.ReadLine());
            List<(int durability, int weight)> eggList = new List<(int durability, int weight)>();
            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int d = inputs[0]; int w = inputs[1];
                eggList.Add((d, w));
            }

            int maxCount = 0;

            CheckSoltion(0);

            void CheckSoltion(int current)
            {
                if (current == N)
                {
                    var countEgg = 0;
                    for (int i = 0; i < N; i++)
                    {
                        if (eggList[i].durability <= 0) countEgg++;

                    }
                    maxCount = Math.Max(maxCount, countEgg);
                    return;
                }

                if (eggList[current].durability <= 0)
                {
                    CheckSoltion(current + 1);
                    return;
                }

                var check = false;
                for (int i = 0; i < N; i++)
                {
                    if (i == current) continue;
                    if (eggList[i].durability > 0)
                    {
                        check = true;
                        break;
                    }
                }

                if (check == false)
                {
                    maxCount = Math.Max(maxCount, N - 1);
                    return;
                }

                for (int i = 0; i < N; i++)
                {
                    var currentEgg = eggList[current];
                    var nextEgg = eggList[i];

                    if (current == i)
                        continue;
                    if (nextEgg.durability <= 0)
                        continue;

                    int currentEggDurability = currentEgg.durability;
                    int currentEggWeight = currentEgg.weight;
                    int nextEggDurability = nextEgg.durability;
                    int nextEggWeight = nextEgg.weight;

                    int calCurrentEggDurability = currentEggDurability - nextEggWeight;
                    int calNextEggDurability = nextEggDurability - currentEggWeight;

                    eggList[current] = (calCurrentEggDurability, currentEggWeight);
                    eggList[i] = (calNextEggDurability, nextEggWeight);

                    CheckSoltion(current + 1);

                    eggList[current] = (currentEggDurability, currentEggWeight);
                    eggList[i] = (nextEggDurability, nextEggWeight);

                }
                return;
            }

            sw.WriteLine(maxCount);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
