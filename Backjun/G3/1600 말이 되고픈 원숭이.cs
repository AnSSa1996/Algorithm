            var sr = new StreamReader(Console.OpenStandardInput());
            var sw = new StreamWriter(Console.OpenStandardOutput());

            var K = int.Parse(sr.ReadLine());
            var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            var W = inputs[0];
            var H = inputs[1];
            var board = new int[H + 1, W + 1];

            for (int y = 0; y < H; y++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int x = 0; x < W; x++)
                {
                    board[y, x] = inputs[x];
                }
            }

            var dx = new int[12] { 1, -1, 0, 0, -2, -2, -1, -1, 1, 1, 2, 2 };
            var dy = new int[12] { 0, 0, 1, -1, -1, 1, -2, 2, -2, 2, -1, 1 };
            
            var queue = new Queue<(int Y, int X,int JUMP)>();
            var visited = new int[H + 1, W + 1, K + 1];
            var max = -1;

            queue.Enqueue((0, 0, 0));
            visited[0, 0, 0] = 0;
            while (queue.Count != 0)
            {
                var (y, x, jump) = queue.Dequeue();
                if (y == H - 1 && x == W - 1)
                {
                    max = visited[y, x, jump];
                    break;
                }

                for (var i = 0; i < 4; i++)
                {
                    var ny = y + dy[i];
                    var nx = x + dx[i];
                    if (ny < 0 || ny >= H || nx < 0 || nx >= W) continue;
                    if (board[ny, nx] == 1) continue;
                    if (visited[ny, nx, jump] != 0) continue;
                    visited[ny, nx, jump] = visited[y, x, jump] + 1;
                    queue.Enqueue((ny, nx, jump));
                }

                if (jump >= K) continue;
                for (var i = 4; i < 12; i++)
                {
                    var ny = y + dy[i];
                    var nx = x + dx[i];
                    if (ny < 0 || ny >= H || nx < 0 || nx >= W) continue;
                    if (board[ny, nx] == 1) continue;
                    if (visited[ny, nx, jump + 1] != 0) continue;
                    visited[ny, nx, jump + 1] = visited[y, x, jump] + 1;
                    queue.Enqueue((ny, nx, jump + 1));
                }
            }
            
            sw.WriteLine(max);
            sw.Close();
            sr.Close();