var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());
for (var t = 0; t < T; t++)
{
    var N = int.Parse(sr.ReadLine());
    var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var pq = new PriorityQueue<long, long>();

    for (var n = 0; n < N; n++)
    {
        pq.Enqueue(input[n], input[n]);
    }

    long answer = 0;
    for (var n = 0; n < N - 1; n++)
    {
        var first = pq.Dequeue();
        var second = pq.Dequeue();
        var result = first + second;
        answer += result;
        pq.Enqueue(result, result);
    }
    
    sw.WriteLine(answer);
}

sw.Flush();
sw.Close();
sr.Close();