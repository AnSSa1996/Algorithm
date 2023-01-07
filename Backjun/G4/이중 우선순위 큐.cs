var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());
for (var t = 0; t < T; t++)
{
    var keyValue = 0;
    var keyDict = new Dictionary<long, bool>();
    var priorityHighQueue = new PriorityQueue<(int key, long value), long>();
    var priorityLowQueue = new PriorityQueue<(int key, long value), long>();

    var N = long.Parse(sr.ReadLine());
    for (var n = 0; n < N; n++)
    {
        var inputs = sr.ReadLine().Split();
        var I = inputs[0];
        var D = long.Parse(inputs[1]);
        if (I == "I")
        {
            priorityHighQueue.Enqueue((keyValue, D), -D);
            priorityLowQueue.Enqueue((keyValue, D), D);
            keyDict.Add(keyValue++, true);
        }

        if (I == "D" && D == 1)
        {
            while (true)
            {
                if (priorityHighQueue.Count == 0) break;
                var pair = priorityHighQueue.Dequeue();
                if (keyDict[pair.key])
                {
                    keyDict[pair.key] = false;
                    break;
                }
            }
        }

        if (I == "D" && D == -1)
        {
            while (true)
            {
                if (priorityLowQueue.Count == 0) break;
                var pair = priorityLowQueue.Dequeue();
                if (keyDict[pair.key])
                {
                    keyDict[pair.key] = false;
                    break;
                }
            }
        }
    }

    var maxCheck = false;
    var minCheck = false;
    long resultMax = 0;
    long resultMin = 0;

    while (true)
    {
        if (priorityHighQueue.Count == 0) break;
        var pair = priorityHighQueue.Dequeue();
        if (keyDict[pair.key])
        {
            maxCheck = true;
            resultMax = pair.value;
            break;
        }
    }

    while (true)
    {
        if (priorityLowQueue.Count == 0) break;
        var pair = priorityLowQueue.Dequeue();
        if (keyDict[pair.key])
        {
            minCheck = true;
            resultMin = pair.value;
            break;
        }
    }

    if (minCheck && maxCheck) sw.WriteLine($"{resultMax} {resultMin}");
    else sw.WriteLine("EMPTY");
}

sr.Close();
sw.Close();