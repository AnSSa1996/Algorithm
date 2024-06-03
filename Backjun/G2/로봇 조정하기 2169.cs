using System;
using System.IO;

namespace Backj
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput());
            var sr = new StreamReader(Console.OpenStandardInput());

            var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            
            var Y = inputs[0];
            var X = inputs[1];
            
            var map = new int[Y, X];

            for (var y = 0; y < Y; y++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (var x = 0; x < X; x++)
                {
                    map[y, x] = inputs[x];
                }
            }
            
            // dp[y, x] = y, x까지 오는데 드는 최댓값
            var dp = new int[Y, X];
            dp[0, 0] = map[0, 0];

            // 초기값 설정
            for (var x = 1; x < X; x++)
            {
                dp[0, x] = dp[0, x - 1] + map[0, x];
            }
            
            for(var y = 1; y < Y; y++)
            {
                var right = new int[X];
                right[0] = dp[y - 1, 0] + map[y, 0];
                for (var x = 1; x < X; x++)
                {
                    right[x] = Math.Max(dp[y - 1, x], right[x - 1]) + map[y, x];
                }

                var left = new int[X];
                left[X - 1] = dp[y - 1, X - 1] + map[y, X - 1];
                for (var x = X - 2; x >= 0; x--)
                {
                    left[x] = Math.Max(dp[y - 1, x], left[x + 1]) + map[y, x];
                }
                
                for (var x = 0; x < X; x++)
                {
                    dp[y, x] = Math.Max(right[x], left[x]);
                }
            }
            
            
            sw.WriteLine(dp[Y - 1, X - 1]);
            sw.Close();
            sr.Close();
        }
    }
}