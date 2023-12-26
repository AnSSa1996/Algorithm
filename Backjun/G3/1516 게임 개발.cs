var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());       // 건물의 수
var buildingTime = new int[N + 1];         // 각 건물을 짓는데 걸리는 시간
var inDegree = new int[N + 1];             // 각 건물의 진입차수
var graph = new List<int>[N + 1];          // 각 건물의 진입차수에 따른 건물 번호


for (int i = 0; i <= N; i++)
{
    graph[i] = new List<int>();
}

for (int i = 1; i <= N; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    buildingTime[i] = inputs[0];

    for (int j = 1; j < inputs.Length - 1; j++)
    {
        graph[inputs[j]].Add(i);
        inDegree[i]++;
    }
}

var buildingQueue = new Queue<int>();
var result = new int[N + 1];

// 기본 빌딩타임을 미리 담는다.
Array.Copy(buildingTime, result, N + 1);

// 진입차수가 0인 것들을 미리 담는다. (선행 조건이 없는 경우)ㄴ
for (int i = 1; i <= N; i++)
{
    if (inDegree[i] == 0)
    {
        buildingQueue.Enqueue(i);
    }
}

while (buildingQueue.Count > 0)
{
    // 현재 빌등을 짓는다.
    var building = buildingQueue.Dequeue();
    for (int i = 0; i < graph[building].Count; i++)
    {
        var nextBuilding = graph[building][i];
        inDegree[nextBuilding]--;
        
        // 아래의 의미는 다음 빌딩의 최대 건설시간은 현재 빌딩의 최대 건설시간 + 다음 빌딩의 건설시간이다.
        result[nextBuilding] = Math.Max(result[nextBuilding], result[building] + buildingTime[nextBuilding]);
        
        // 건물을 지을 수 있을 때, 큐에 담는다.
        if (inDegree[nextBuilding] == 0)
        {
            buildingQueue.Enqueue(nextBuilding);
        }
    }
}

for (int i = 1; i <= N; i++)
{
    sw.WriteLine(result[i]);
}

sr.Close();
sw.Close();