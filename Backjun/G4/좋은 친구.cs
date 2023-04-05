var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = input[0];
var K = input[1];

var lstQueue = new List<Queue<int>>();
for (var i = 0; i <= 20; i++) lstQueue.Add(new Queue<int>());
long answer = 0;
for (var n = 0; n < N; n++)
{
    var length = sr.ReadLine().Length;
    lstQueue[length].Enqueue(n);
    while (lstQueue[length].Peek() < n - K)
    {
        lstQueue[length].Dequeue();
    }

    answer += lstQueue[length].Count - 1;
}

sw.WriteLine(answer);

sw.Flush();
sw.Close();
sr.Close();