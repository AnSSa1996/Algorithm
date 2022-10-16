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

            int N = int.Parse(sr.ReadLine());
            List<int> crain = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
            crain.Sort((a, b) => b - a);

            int K = int.Parse(sr.ReadLine());
            List<int> box = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
            box.Sort((a, b) => a - b);


            int result = 0;

            if (box.Last() > crain[0])
            {
                sw.WriteLine(-1);
                sw.Flush();
                sw.Close();
                sr.Close();
                return;
            }
            while (true)
            {
                for (int crainIndex = 0; crainIndex < crain.Count(); crainIndex++)
                {
                    for (int boxIndex = box.Count() - 1; boxIndex >= 0; boxIndex--)
                    {
                        if (crain[crainIndex] >= box[boxIndex])
                        {
                            box.RemoveAt(boxIndex--);
                            break;
                        }
                    }
                }
                result++;
                if (box.Count() == 0) break;
            }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
