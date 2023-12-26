var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var n = int.Parse(sr.ReadLine());       // 도시의 갯수
var m = int.Parse(sr.ReadLine());       // 버스의 갯수

var map = new List<(int start, int end, int weight)>();    // 버스의 정보를 저장할 리스트
var max = 1000000000;                       // 최대값

var nearestArray = new int[n+1];                 // 가장 가까운 도시를 저장할 배열
var distanceArray = new int[n+1];                // 시작점에서 해당 도시까지의 거리를 저장할 배열

for (var i = 1; i <= n; i++)
{
    nearestArray[i] = 1;
    distanceArray[i] = max;
}

for (var i = 0; i < m; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    var start = inputs[0];
    var end = inputs[1];
    var weight = inputs[2];

    map.Add((start, end, weight));
}

void Dijkstra(int first)
{
    var priorityQueue = new PriorityQueue<(int city, int priority), int>();
    priorityQueue.Enqueue((first, 0), 0);
    
    
    while (priorityQueue.Count > 0)
    {
        var (current, distance) = priorityQueue.Dequeue();
        if (distance > distanceArray[current]) continue;
        
        foreach (var (start, end, weight) in map)
        {
            if (current != start) continue;
            var nextDistance = distance + weight;
            if (nextDistance >= distanceArray[end]) continue;
            distanceArray[end] = nextDistance;
            nearestArray[end] = start;
            priorityQueue.Enqueue((end, nextDistance), nextDistance);
        }
    }
}

var inputs2 = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
var start2 = inputs2[0];
var end2 = inputs2[1];

Dijkstra(start2);

var count = 0;
var stack = new Stack<int>();

sw.WriteLine(distanceArray[end2]);

while (end2 != start2)
{
    stack.Push(end2);
    end2 = nearestArray[end2];
    count++;
}

stack.Push(start2);
stack.Reverse();
sw.WriteLine(count + 1);
sw.WriteLine(string.Join(" ", stack));

sr.Close();
sw.Close();