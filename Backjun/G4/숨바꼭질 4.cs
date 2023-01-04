var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var map = new int[2000001];
var visited = new bool[2000001];
var end = 1000000;
var N = inputs[0];
var K = inputs[1];

void BFS()
{
    var q = new Queue<int>();
    q.Enqueue(N);
    map[N] = N;
    while (q.Count > 0)
    {
        var current = q.Dequeue();
        if (current == K)
        {
            break;
        }

        var multiply = current * 2;
        if (multiply <= end && visited[multiply] == false)
        {
            visited[multiply] = true;
            map[multiply] = current;
            q.Enqueue(multiply);
        }

        var front = current + 1;
        if (front <= end && visited[front] == false)
        {
            visited[front] = true;
            map[front] = current;
            q.Enqueue(front);
        }

        var back = current - 1;
        if (back >= 0 && visited[back] == false)
        {
            visited[back] = true;
            map[back] = current;
            q.Enqueue(back);
        }
    }
}

BFS();
var result = new List<int>();
var current = K;
result.Add(current);
while (true)
{
    if (current == N) break;
    current = map[current];
    result.Add(current);
}

result.Reverse();
sw.WriteLine(result.Count - 1);
sw.WriteLine(string.Join(" ", result));

sw.Close();
sr.Close();