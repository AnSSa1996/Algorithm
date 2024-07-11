var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());
for (var i = 0; i < T; i++)
{
    var N = int.Parse(sr.ReadLine());
    var numList = new List<int>();

    for (var n = 0; n < N / 10 + 1; n++)
    {
        var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        numList.AddRange(nums);
    }

    var leftPQ = new PriorityQueue<int, int>();
    var rightPQ = new PriorityQueue<int, int>();
    var result = new List<int>();

    for (var j = 0; j < N; j++)
    {
        if (leftPQ.Count == rightPQ.Count)
        {
            rightPQ.Enqueue(numList[j], numList[j]);
        }
        else
        {
            leftPQ.Enqueue(numList[j], -numList[j]);
        }

        if (leftPQ.Count > 0 && rightPQ.Count > 0 && leftPQ.Peek() > rightPQ.Peek())
        {
            var left = leftPQ.Dequeue();
            var right = rightPQ.Dequeue();

            leftPQ.Enqueue(right, -right);
            rightPQ.Enqueue(left, left);
        }


        if (j % 2 == 0)
        {
            result.Add(rightPQ.Peek());
        }
    }
    var resultCount = result.Count;
    sw.WriteLine(resultCount);
    for (var r = 0; r < resultCount; r++)
    {
        sw.Write(result[r] + " ");
        if (r % 10 == 9)
        {
            sw.WriteLine();
        }
    }
}

sw.Flush();
sw.Close();
sr.Close();