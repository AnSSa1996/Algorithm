var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());   // 대학의 강의 수
var priorityQueue = new PriorityQueue<(int d, int p), int>();

for (int i = 0; i < N; i++)
{
    var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    priorityQueue.Enqueue((input[0], input[1]), -input[0]);
}

var visited = new bool[10001];
var result = 0;
while (priorityQueue.Count > 0)
{
    var (d, p) = priorityQueue.Dequeue();
    for (var i = p; i > 0; i--)
    {
        if (visited[i] == false)
        {
            visited[i] = true;
            result += d;
            break;
        }
    }
}

sw.WriteLine(result);
sw.Close();
sr.Close();