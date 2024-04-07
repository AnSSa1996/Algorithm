var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var N = long.Parse(sr.ReadLine()); // 숙제의 개수
var priorityQueue = new PriorityQueue<long, long>();

var homeworks = new List<long>[N + 1];
for (var i = 0; i < N + 1; i++)
{
    homeworks[i] = new List<long>();
}

for (var i = 0; i < N; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
    var deadline = inputs[0];
    var score = inputs[1];
    homeworks[deadline].Add(score);
}

long currentDay = 0;
long totalScore = 0;
for (var i = N; i > 0; i--)
{
    foreach (var score in homeworks[i])
    {
        priorityQueue.Enqueue(score, -score);
    }

    if (priorityQueue.Count > 0)
    {
        var value = priorityQueue.Dequeue();
        totalScore += value;
    }
}

sw.WriteLine(totalScore);
sr.Close();
sw.Close();