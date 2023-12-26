            var sr = new StreamReader(Console.OpenStandardInput());
            var sw = new StreamWriter(Console.OpenStandardOutput());

            var dy = new int[] { 0, 0, 1, -1 };
            var dx = new int[] { 1, -1, 0, 0 };

            var N = int.Parse(sr.ReadLine());
            var map = new int[N, N];
            for (var y = 0; y < N; y++)
            {
                var line = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (var x = 0; x < N; x++)
                {
                    map[y, x] = line[x];
                }
            }

            var isLand = 2;
            for (var y = 0; y < N; y++)
            {
                for (var x = 0; x < N; x++)
                {
                    if (map[y, x] == 1)
                    {
                        BFS_IsLand(y, x, isLand);
                        isLand++;
                    }
                }
            }

            var ans = int.MaxValue;
            for (var i = 2; i < isLand; i++)
            {
                ans = Math.Min(ans, BFS_Bridge(i));
            }

            sw.WriteLine(ans);


            void BFS_IsLand(int y, int x, int cnt)
            {
                var q = new Queue<(int y, int x)>();
                q.Enqueue((y, x));
                map[y, x] = cnt;

                while (q.Any())
                {
                    var (nowY, nowX) = q.Dequeue();
                    for (var d = 0; d < 4; d++)
                    {
                        var nextY = nowY + dy[d];
                        var nextX = nowX + dx[d];
                        if (nextX < 0 || nextY < 0 || nextY >= N || nextX >= N) continue;
                        if (map[nextY, nextX] != 1) continue;
                        map[nextY, nextX] = cnt;
                        q.Enqueue((nextY, nextX));
                    }
                }
            }

            int BFS_Bridge(int islandIndex)
            {
                var q = new Queue<(int y, int x)>();
                var dist = new int[N, N];
                for (var y = 0; y < N; y++)
                {
                    for (var x = 0; x < N; x++)
                    {
                        dist[y, x] = -1;
                        if (map[y, x] == islandIndex)
                        {
                            q.Enqueue((y, x));
                            dist[y, x] = 0;
                        }
                    }
                }

                while (q.Any())
                {
                    var (nowY, nowX) = q.Dequeue();
                    for (var d = 0; d < 4; d++)
                    {
                        var nextY = nowY + dy[d];
                        var nextX = nowX + dx[d];
                        if (nextX < 0 || nextY < 0 || nextY >= N || nextX >= N) continue;

                        if (dist[nextY, nextX] != -1) continue;

                        if (map[nextY, nextX] == 0)
                        {
                            dist[nextY, nextX] = dist[nowY, nowX] + 1;
                            q.Enqueue((nextY, nextX));
                        }
                        else if (map[nextY, nextX] != islandIndex)
                        {
                            return dist[nowY, nowX];
                        }
                    }
                }

                return int.MaxValue;
            }


            sw.Flush();
            sw.Close();
            sr.Close();