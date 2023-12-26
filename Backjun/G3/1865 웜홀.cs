using System.Text;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine()); // 테스트 케이스의 개수
var max = 1000000000;

var stringBuilder = new StringBuilder();

for (var t = 0; t < T; t++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    var N = inputs[0]; // 지점
    var M = inputs[1]; // 도로
    var W = inputs[2]; // 웜홀

    var map = new List<(int start, int end, int time)>(); // (출발, 도착, 시간)
    var distances = new int[N + 1]; // 출발지점에서 각 지점까지의 최단거리

    for (var i = 0; i < M; i++)
    {
        inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
        var start = inputs[0];
        var end = inputs[1];
        var time = inputs[2];
        map.Add((start, end, time));
        map.Add((end, start, time));
    }

    for (var i = 0; i < W; i++)
    {
        inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
        var start = inputs[0];
        var end = inputs[1];
        var time = inputs[2];
        map.Add((start, end, -time));
    }

    var result = "NO";
    var visited = new bool[N + 1];
    for (var i = 1; i <= N; i++)
    {
        distances[i] = max;
    }


    for (var first = 1; first <= N; first++)
    {
        if (result == "YES") break;
        if (visited[first]) continue;
        distances[first] = 0;
        visited[first] = true;
        bool updated;
        for (var i = 1; i < N; i++)
        {
            updated = false;
            foreach (var (start, end, time) in map)
            {
                if (distances[start] < max && distances[end] > distances[start] + time)
                {
                    distances[end] = distances[start] + time;
                    visited[end] = true;
                    updated = true;
                }
            }

            if (!updated) break;
        }

        foreach (var (start, end, time) in map)
        {
            if (distances[start] < max && distances[end] > distances[start] + time)
            {
                result = "YES";
                break;
            }
        }
    }

    stringBuilder.AppendLine(result);
}

sw.Write(stringBuilder.ToString());
sr.Close();
sw.Close();