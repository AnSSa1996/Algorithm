 var sr = new StreamReader(Console.OpenStandardInput());
            var sw = new StreamWriter(Console.OpenStandardOutput());

            var dx = new[] { 0, 0, 1, -1 };
            var dy = new[] { 1, -1, 0, 0 };

            var input = sr.ReadLine().Split(' ');
            var Y = int.Parse(input[0]);
            var X = int.Parse(input[1]);
            var cheeseMap = new int[Y, X];
            var meltMap = new int[Y, X];

            for (var i = 0; i < Y; i++)
            {
                var line = sr.ReadLine().Split(' ');
                for (var j = 0; j < X; j++)
                {
                    cheeseMap[i, j] = int.Parse(line[j]);
                }
            }

            var answer = 0;
            while (true)
            {
                meltMap = new int[Y, X];
                BFS();
                if (Melt() == false) break;
                answer++;
            }

            sw.WriteLine(answer);

            void BFS()
            {
                var q = new Queue<(int y, int x)>();
                q.Enqueue((0, 0));
                meltMap[0, 0] = 1;

                while (q.Any())
                {
                    var (y, x) = q.Dequeue();
                    for (var d = 0; d < 4; d++)
                    {
                        var ny = y + dy[d];
                        var nx = x + dx[d];
                        if (ny < 0 || ny >= Y || nx < 0 || nx >= X) continue;
                        if (cheeseMap[ny, nx] == 1) meltMap[ny, nx]++;
                        if (meltMap[ny, nx] != 0) continue;
                        q.Enqueue((ny, nx));
                        meltMap[ny, nx] = 1;
                    }
                }
            }

            bool Melt()
            {
                var isMelt = false;
                var meltList = new List<(int y, int x)>();

                for (var i = 0; i < Y; i++)
                {
                    for (var j = 0; j < X; j++)
                    {
                        if (cheeseMap[i, j] != 1) continue;
                        if (meltMap[i, j] < 2) continue;
                        meltList.Add((i, j));
                        isMelt = true;
                    }
                }

                foreach (var meltPair in meltList)
                {
                    var (y, x) = meltPair;
                    cheeseMap[y, x] = 0;
                }

                return isMelt;
            }

            sw.Flush();
            sw.Close();
            sr.Close();