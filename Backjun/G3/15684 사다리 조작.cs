            var sr = new StreamReader(Console.OpenStandardInput());
            var sw = new StreamWriter(Console.OpenStandardOutput());

            var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            var N = inputs[0]; // 세로줄의 수
            var M = inputs[1]; // 가로줄의 수
            var H = inputs[2]; // 가로줄을 놓을 수 있는 위치의 수

            var board = new int[H + 1, N + 1];
            var answer = 4;

            bool Check()
            {
                for (var i = 1; i <= N; i++)
                {
                    var start = i;
                    var height = 1;
                    while (height <= H)
                    {
                        if (board[height, start] == 1)
                        {
                            start++;
                        }
                        else if (board[height, start - 1] == 1)
                        {
                            start--;
                        }
                        
                        height++;
                    }

                    if (start != i)
                    {
                        return false;
                    }
                }

                return true;
            }

            void DFS(int count, int x, int y)
            {
                if (count >= answer)
                {
                    return;
                }

                if (Check())
                {
                    answer = count;
                    return;
                }

                if (count == 3)
                {
                    return;
                }

                for (var i = x; i <= H; i++)
                {
                    for (var j = 1; j < N; j++)
                    {
                        if (board[i, j] == 1 || board[i, j - 1] == 1 || board[i, j + 1] == 1)
                        {
                            continue;
                        }

                        board[i, j] = 1;
                        DFS(count + 1, i, j);
                        board[i, j] = 0;
                    }
                }
            }
            
            for (var i = 0; i < M; i++)
            {
                var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                board[input[0], input[1]] = 1;
            }
            
            DFS(0, 1, 1);
            
            if (answer == 4)
            {
                answer = -1;
            }
            
            sw.WriteLine(answer);

            sw.Close();
            sr.Close();