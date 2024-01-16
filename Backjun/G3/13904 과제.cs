var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var priorityQueue = new PriorityQueue<(int d, int w), int>();
for (var i = 0; i < N; i++)
{
    var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    priorityQueue.Enqueue((input[0], input[1]), -input[1]);
}

var time = new bool[1001];
var result = 0;

for (var i = 0; i < N; i++)
{
    var (d, w) = priorityQueue.Dequeue();
    for (var currentTime = d; currentTime > 0; currentTime--)
    {
        if (time[currentTime] == false)
        {
            time[currentTime] = true;
            result += w;
            break;
        }
    }
}

sw.WriteLine(result);
sw.Close();
sr.Close();