var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());
for (int t = 0; t < T; t++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var N = inputs[0];
    var K = inputs[1];
    var buildings = (new[] { 0 }).Concat(Array.ConvertAll(sr.ReadLine().Split(), int.Parse)).ToArray();

    var buildingRequirementList = new List<List<int>>();
    var buildingTime = new int[N + 1];
    var buildingRequirementCount = new int[N + 1];
    for (var i = 0; i <= N; i++)
    {
        buildingRequirementList.Add(new List<int>());
    }

    for (var i = 0; i < K; i++)
    {
        var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        var x = input[0];
        var y = input[1];
        buildingRequirementList[x].Add(y);
        buildingRequirementCount[y]++;
    }

    var W = int.Parse(sr.ReadLine());
    var queue = new Queue<int>();
    for (var n = 1; n <= N; n++)
    {
        if (buildingRequirementCount[n] == 0)
        {
            queue.Enqueue(n);
            buildingTime[n] = buildings[n];
        }
    }

    while (queue.Count > 0)
    {
        var current = queue.Dequeue();
        if (current == W) break;

        foreach (var next in buildingRequirementList[current])
        {
            buildingTime[next] = Math.Max(buildingTime[next], buildingTime[current] + buildings[next]);
            buildingRequirementCount[next]--;
            if (buildingRequirementCount[next] == 0)
            {
                queue.Enqueue(next);
            }
        }
    }

    sw.WriteLine(buildingTime[W]);
}

sr.Close();
sw.Close();