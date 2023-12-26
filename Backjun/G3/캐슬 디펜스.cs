var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
var N = inputs[0];          // 격자판 행의 수
var M = inputs[1];          // 격자판 열의 수
var D = inputs[2];          // 궁수의 공격 거리 제한

var map = new int[N, M];       // 격자판

for (var y = 0; y < N; y++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    for (var x = 0; x < M; x++)
    {
        map[y, x] = inputs[x];
    }
}


var max = 0;
for (var i = 0; i < M; i++)
{
    for (var j = i + 1; j < M; j++)
    {
        for (var k = j + 1; k < M; k++)
        {
            // 궁수의 위치
            var archer = new int[] { i, j, k };
            
            // 맵 복사
            var copyMap = new int[N, M];
            Array.Copy(map, copyMap, map.Length);
            
            var count = 0;
            
            for(var turn = 0; turn < N; turn++)
            {
                count += AttackEnemy(copyMap, archer);
                MoveEnemy(copyMap);
            }
            
            max = Math.Max(max, count);
        }
    }
}

sw.WriteLine(max);

void MoveEnemy(int [,] copyMap)
{
    for (var y = N - 1; y >= 0; y--)
    {
        for (var x = 0; x < M; x++)
        {
            if (copyMap[y, x] == 1)
            {
                if (y == N - 1)
                {
                    copyMap[y, x] = 0;
                    continue;
                }
                
                copyMap[y + 1, x] = 1;
                copyMap[y, x] = 0;
            }
        }
    }
}

int AttackEnemy(int[,] copyMap, int[] archerPosition)
{
    var count = 0;
    var targets = new List<(int y, int x)>();
    
    foreach (var archer in archerPosition)
    {
        var target = FindClosetTarget(copyMap, archer);
        if (target.y != -1 && target.x != -1)
        {
            targets.Add(target);
        }
    }
    
    foreach (var target in targets)
    {
        if (copyMap[target.y, target.x] == 1)
        {
            copyMap[target.y, target.x] = 0;
            count++;
        }
    }

    return count;
}

(int y, int x) FindClosetTarget(int[,] copyMap, int y)
{
    var target = (y: -1, x: -1);
    var minDistance = int.MaxValue;
    
    var queue = new Queue<(int y, int x, int distance)>();
    var dy = new int[] { 0, -1, 0 }; // 왼쪽, 위, 오른쪽
    var dx = new int[] { -1, 0, 1 }; // 왼쪽, 위, 오른쪽

    // 맨 아래 행부터 탐색
    queue.Enqueue((N - 1, y, 1));
    
    while (queue.Count > 0)
    {
        var (nextY, nextX, distance) = queue.Dequeue();
        if (distance > D) continue;
        
        if (copyMap[nextY, nextX] == 1)
        {
            target = (nextY, nextX);
            break;
        }
        
        for (var i = 0; i < 3; i++)
        {
            var (ny, nx) = (nextY + dy[i], nextX + dx[i]);
            if (ny < 0 || ny >= N || nx < 0 || nx >= M) continue;
            queue.Enqueue((ny, nx, distance + 1));
        }
    }
    
    return target;
}

sr.Close();
sw.Close();