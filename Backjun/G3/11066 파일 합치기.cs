            var sr = new StreamReader(Console.OpenStandardInput());
            var sw = new StreamWriter(Console.OpenStandardOutput());
            var T = int.Parse(sr.ReadLine());

            for (var t = 0; t < T; t++)
            {
                var N = int.Parse(sr.ReadLine());
                var files = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var prefixSum = new int[N + 1];
                var dp = new int[N + 1, N + 1];

                for (var i = 1; i <= N; i++)
                {
                    prefixSum[i] = prefixSum[i - 1] + files[i - 1];
                }

                for (var i = 1; i <= N; i++)
                {
                    for (var j = i; j <= N; j++)
                    {
                        dp[i, j] = int.MaxValue;
                    }
                }

                for (var i = 1; i <= N; i++)
                {
                    dp[i, i] = 0;
                }

                for (var gap = 1; gap < N; gap++)
                {
                    for (var i = 1; i + gap <= N; i++)
                    {
                        var j = i + gap;
                        for (var k = i; k < j; k++)
                        {
                            dp[i, j] = Math.Min(dp[i, j], dp[i, k] + dp[k + 1, j] + prefixSum[j] - prefixSum[i - 1]);
                        }
                    }
                }
                
                sw.WriteLine(dp[1, N]);
            }

            sw.Flush();
            sw.Close();
            sr.Close();