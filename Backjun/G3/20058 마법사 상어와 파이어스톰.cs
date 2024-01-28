var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];          // 격자의 칸 2진수
var Q = inputs[1];          // 파이어스톰
var L = 1 << N;             // 격자의 크기

var A = new int[L, L];      // 격자

var dx = new int[] { 0, 1, 0, -1 };
var dy = new int[] { 1, 0, -1, 0 };

for (var i = 0; i < L; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var j = 0; j < L; j++)
    {
        A[i, j] = inputs[j];
    }
}

var Lsteps = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

void FireStorm(int step)
{
    var size = 1 << step;

    for (var startY = 0; startY < L; startY += size)
    {
        for(var startX = 0; startX < L; startX += size)
        {
            var temp = new int[size, size];
            
            for (var y = 0; y < size; y++)
            {
                for (var x = 0; x < size; x++)
                {
                    temp[y, x] = A[startY + size - x - 1, startX + y];
                }
            }

            for (var y = 0; y < size; y++)
            {
                for (var x = 0; x < size; x++)
                {
                    A[startY + y, startX + x] = temp[y, x];
                }
            }
        }
    }
}

void Melt()
{
    var meltQueue = new Queue<(int y, int x)>();

    for (var y = 0; y < L; y++)
    {
        for (var x = 0; x < L; x++)
        {
            if (A[y, x] == 0) continue;

            var count = 0;
            for (var i = 0; i < 4; i++)
            {
                var ny = y + dy[i];
                var nx = x + dx[i];

                if (ny < 0 || ny >= L || nx < 0 || nx >= L) continue;
                if (A[ny, nx] == 0) continue;
                count++;
            }
            if (count < 3)
            {
                meltQueue.Enqueue((y, x));
            }
        }
    }

    foreach (var melt in meltQueue)
    {
        A[melt.y, melt.x]--;
    }
}

for (var i = 0; i < Q; i++)
{
    FireStorm(Lsteps[i]);
    Melt();
}

var sum = 0;
var max = 0;

void CheckResult()
{
    var visited = new bool[L, L];
    var queue = new Queue<(int y, int x)>();
    

    for (var y = 0; y < L; y++)
    {
        for (var x = 0; x < L; x++)
        {
            if (A[y, x] == 0 || visited[y, x]) continue;

            var count = 0;
            queue.Enqueue((y, x));
            visited[y, x] = true;
            sum += A[y, x];

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                count++;

                for (var i = 0; i < 4; i++)
                {
                    var ny = current.y + dy[i];
                    var nx = current.x + dx[i];

                    if (ny < 0 || ny >= L || nx < 0 || nx >= L) continue;
                    if (A[ny, nx] == 0 || visited[ny, nx]) continue;

                    queue.Enqueue((ny, nx));
                    visited[ny, nx] = true;
                    sum += A[ny, nx];
                }
            }
            
            max = Math.Max(max, count);
        }
    }
}

CheckResult();
sw.WriteLine(sum);
sw.WriteLine(max);
sw.Close();
sr.Close();