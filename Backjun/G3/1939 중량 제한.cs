var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
var N = inputs[0]; // 섬의 갯수
var M = inputs[1]; // 다리의 갯수

var bridgeDict = new Dictionary<int, List<(int target, int weight)>>();
var maxWeight = 0;
for (var i = 0; i < M; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    if (bridgeDict.ContainsKey(inputs[0]))
    {
        bridgeDict[inputs[0]].Add((inputs[1], inputs[2]));
    }
    else
    {
        bridgeDict.Add(inputs[0], new List<(int target, int weight)> { (inputs[1], inputs[2]) });
    }

    if (bridgeDict.ContainsKey(inputs[1]))
    {
        bridgeDict[inputs[1]].Add((inputs[0], inputs[2]));
    }
    else
    {
        bridgeDict.Add(inputs[1], new List<(int target, int weight)> { (inputs[0], inputs[2]) });
    }

    maxWeight = Math.Max(maxWeight, inputs[2]);
}

inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
var start = inputs[0];
var target = inputs[1];

var left = 0;
var right = maxWeight;

while (left <= right)
{
    var mid = (left + right) / 2;
    var queue = new Queue<int>();
    var visited = new bool[N + 1];
    queue.Enqueue(start);
    visited[start] = true;

    while (queue.Count > 0)
    {
        var current = queue.Dequeue();
        if (bridgeDict.ContainsKey(current) == false) continue;
        foreach (var bridge in bridgeDict[current])
        {
            if (bridge.weight < mid) continue;
            if (visited[bridge.target]) continue;
            queue.Enqueue(bridge.target);
            visited[bridge.target] = true;
        }
    }

    if (visited[target])
    {
        left = mid + 1;
    }
    else
    {
        right = mid - 1;
    }
}

sw.WriteLine(right);
sr.Close();
sw.Close();