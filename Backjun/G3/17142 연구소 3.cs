var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());


var inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
var N = inputs[0];              // 연구소의 크기
var M = inputs[1];              // 활성화 할 수 있는 바이러스의 개수

var map = new int[N, N];                    // 연구소
var virus = new List<(int y, int x)>();     // 바이러스 위치
var emptyCount = 0;                         // 빈칸 개수

for (var y = 0; y < N; y++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    for (var x = 0; x < N; x++)
    {
        map[y, x] = inputs[x];
        if (map[y, x] == 2)
        {
            virus.Add((y, x));
            continue;
        }

        if (map[y, x] == 0)
        {
            emptyCount++;
            continue;
        }
    }
}

// 바이러스를 활성화 시킬 수 있는 모든 경우의 수
var virusComb = new List<List<(int y, int x)>>();
Comb(virus, M, 0, new List<(int y, int x)>(), virusComb);

void Comb(List<(int y, int x)> virus, int m, int start, List<(int y, int x)> selected, List<List<(int y, int x)>> result)
{
    if (m == 0)
    {
        result.Add(selected);
        return;
    }

    for (var i = start; i < virus.Count; i++)
    {
        var newSelected = new List<(int y, int x)>(selected);
        newSelected.Add(virus[i]);
        Comb(virus, m - 1, i + 1, newSelected, result);
    }
}



var result = int.MaxValue;

if (emptyCount == 0)
{
    sw.WriteLine(0);
    sr.Close();
    sw.Close();
    return;
}

// 바이러스를 활성화 시킨 후, 빈칸의 개수를 세어 최대값을 구한다.
foreach (var comb in virusComb)
{
    var newMap = new int[N, N];
    Array.Copy(map, newMap, map.Length);

    var queue = new Queue<(int y, int x, int time)>();
    foreach (var v in comb)
    {
        queue.Enqueue((v.y, v.x, 0));
        newMap[v.y, v.x] = 3;
    }

    var count = 0;
    while (queue.Count > 0)
    {
        var (y, x, time) = queue.Dequeue();

        if (y > 0 && newMap[y - 1, x] == 2)
        {
            queue.Enqueue((y - 1, x, time + 1));
            newMap[y - 1, x] = 3;
        }

        if (y > 0 && newMap[y - 1, x] == 0)
        {
            queue.Enqueue((y - 1, x, time + 1));
            newMap[y - 1, x] = 3;
            count++;
        }
        
        if (y < N - 1 && newMap[y + 1, x] == 2)
        {
            queue.Enqueue((y + 1, x, time + 1));
            newMap[y + 1, x] = 3;
        }

        if (y < N - 1 && newMap[y + 1, x] == 0)
        {
            queue.Enqueue((y + 1, x, time + 1));
            newMap[y + 1, x] = 3;
            count++;
        }
        
        if (x > 0 && newMap[y, x - 1] == 2)
        {
            queue.Enqueue((y, x - 1, time + 1));
            newMap[y, x - 1] = 3;
        }

        if (x > 0 && newMap[y, x - 1] == 0)
        {
            queue.Enqueue((y, x - 1, time + 1));
            newMap[y, x - 1] = 3;
            count++;
        }
        
        if (x < N - 1 && newMap[y, x + 1] == 2)
        {
            queue.Enqueue((y, x + 1, time + 1));
            newMap[y, x + 1] = 3;
        }

        if (x < N - 1 && newMap[y, x + 1] == 0)
        {
            queue.Enqueue((y, x + 1, time + 1));
            newMap[y, x + 1] = 3;
            count++;
        }
        
        if (count >= emptyCount)
        {
            result = Math.Min(result, time + 1);
            continue;
        }
    }
}

sw.WriteLine(result == int.MaxValue ? -1 : result);
sr.Close();
sw.Close();