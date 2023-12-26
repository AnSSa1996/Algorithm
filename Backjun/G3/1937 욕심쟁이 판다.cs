            var sr = new StreamReader(Console.OpenStandardInput());
            var sw = new StreamWriter(Console.OpenStandardOutput());

            var dx = new int[] { 0, 0, 1, -1 };
            var dy = new int[] { 1, -1, 0, 0 };
            
            var N = int.Parse(sr.ReadLine());
            var forest = new int[N, N];
            var dp = new int[N, N];

            for (var y = 0; y < N; y++)
            {
                var line = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for(var x = 0; x < N; x++)
                {
                    forest[y, x] = line[x];
                    dp[y, x] = -1;
                }
            }

            var maxDays = 0;
            
            for(var y = 0; y < N; y++)
            {
                for(var x = 0; x < N; x++)
                {
                    maxDays = Math.Max(maxDays, DFS(y, x));
                }
            }

            int DFS(int y, int x)
            {
                if (dp[y, x] != -1) return dp[y, x];
                dp[y, x] = 1;

                for (var d = 0; d < 4; d++)
                {
                    var ny = y + dy[d];
                    var nx = x + dx[d];
                    
                    if (ny < 0 || ny >= N || nx < 0 || nx >= N) continue;
                    if (forest[ny, nx] <= forest[y, x]) continue;
                    dp[y, x] = Math.Max(dp[y, x], DFS(ny, nx) + 1);
                }
                
                return dp[y, x];
            }
            
            sw.WriteLine(maxDays);

            sw.Flush();
            sw.Close();
            sr.Close();