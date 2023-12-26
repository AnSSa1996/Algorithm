 bool[] isPrime = null;
            var isPrimeList = new List<int>();
            
            var sr = new StreamReader(Console.OpenStandardInput());
            var sw = new StreamWriter(Console.OpenStandardOutput());
            var N = int.Parse(sr.ReadLine());
            Eratos(N);
            
            for (var i = 2; i <= N; i++)
            {
                if (isPrime[i])
                {
                    isPrimeList.Add(i);
                }
            }

            var start = 0;
            var end = 0;
            var count = 0;
            var sum = 0;
            
            while (true)
            {
                if (sum >= N)
                {
                    sum -= isPrimeList[start];
                    start++;
                }
                else if (end == isPrimeList.Count)
                {
                    break;
                }
                else
                {
                    sum += isPrimeList[end];
                    end++;
                }
                
                if (sum == N)
                {
                    count++;
                }
            }
            
            sw.WriteLine(count);

            sw.Flush();
            sw.Close();
            sr.Close();

            void Eratos(int n)
            {
                isPrime = new bool[n + 1];
                
                for (var i = 2; i <= n; i++)
                {
                    isPrime[i] = true;
                }

                for (var i = 2; i * i <= n; i++)
                {
                    if (isPrime[i] == false) continue;
                    for (var j = i * i; j <= n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }