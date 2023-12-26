using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var sr = new StreamReader(Console.OpenStandardInput());
            var sw = new StreamWriter(Console.OpenStandardOutput());
            var T = int.Parse(sr.ReadLine());

            for (var t = 0; t < T; t++)
            {
                var N = int.Parse(sr.ReadLine());
                var arr = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var visited = new bool[N + 1];
                var done = new bool[N + 1];
                var count = 0;
                
                for(var i = 1; i <= N; i++)
                {
                    if (visited[i]) continue;
                    DFS(i);
                }
                
                sw.WriteLine(N - count);

                void DFS(int current)
                {
                    visited[current] = true;
                    var next = arr[current - 1];

                    if (visited[next] == false)
                    {
                        DFS(next);
                    }
                    else if(done[next] == false)
                    {
                        for(var i = next; i != current; i = arr[i - 1])
                        {
                            count++;
                        }
                        count++;
                    }
                    done[current] = true;
                }
            }
            
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
