var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

var N = inputs[0];      // 문제의 수
var M = inputs[1];      // 먼저 푸는 것이 좋은 문데의 갯수

var problemArray = new int[N + 1];
var problemList = new List<int>[N + 1];

for (var i = 1; i <= N; i++)
{
    problemList[i] = new List<int>();
}

for (var m = 0; m < M; m++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var a = inputs[0];
    var b = inputs[1];

    problemArray[b]++;
    problemList[a].Add(b);
}

var result = new List<int>();
var queue = new PriorityQueue<int, int>();
for (var i = 1; i <= N; i++)
{
    if (problemArray[i] == 0)
    {
        queue.Enqueue(i, i);
    }
}

while (queue.Count > 0)
{
    var problem = queue.Dequeue();
    result.Add(problem);
    foreach (var nextProblem in problemList[problem])
    {
        problemArray[nextProblem]--;
        if (problemArray[nextProblem] == 0)
        {
            queue.Enqueue(nextProblem, nextProblem);
        }
    }
}

sw.WriteLine(string.Join(" ", result));
sw.Close();
sr.Close();