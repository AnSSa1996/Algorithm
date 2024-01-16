var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var Array = new char[5, 5];     // 5x5 배열

for (var i = 0; i < 5; i++)
{
    var line = sr.ReadLine();
    for (var j = 0; j < 5; j++)
    {
        Array[i, j] = line[j];
    }
}

var dy = new int[] { -1, 1, 0, 0 };
var dx = new int[] { 0, 0, -1, 1 };
var result = 0;

var position = new List<(int y, int x)>();

void DFS(int depth, int yCount, int index)
{
    if (yCount >= 4) return;            // 4개 이상의 y가 선택되었을 경우
    if (25 - index + depth < 7) return; // 남은 칸의 수가 7개 미만일 경우
    
    if (depth == 7)
    {
        var visited = new bool[5, 5];
        var queue = new Queue<(int y, int x)>();
        queue.Enqueue(position[0]);
        visited[position[0].y, position[0].x] = true;

        var count = 1;
        while (queue.Count > 0)
        {
            var (y, x) = queue.Dequeue();
            for (var i = 0; i < 4; i++)
            {
                var ny = y + dy[i];
                var nx = x + dx[i];
                if (ny < 0 || ny >= 5 || nx < 0 || nx >= 5) continue;
                if (visited[ny, nx]) continue;
                if (position.Contains((ny, nx)) == false) continue;
                visited[ny, nx] = true;
                queue.Enqueue((ny, nx));
                count++;
            }
        }

        if (count == 7) result++;
        return;
    }
    
    for (var i = index; i < 25; i++)
    {
        var (y, x) = (i / 5, i % 5);
        position.Add((y, x));
        DFS(depth + 1, yCount + (Array[y, x] == 'Y' ? 1 : 0), i + 1);
        position.RemoveAt(position.Count - 1);
    }
}

DFS(0, 0, 0);
sw.WriteLine(result);
sw.Close();
sr.Close();
