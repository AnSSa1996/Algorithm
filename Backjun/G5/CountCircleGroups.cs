StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());

for (var i = 0; i < T; i++)
{
    var n = int.Parse(sr.ReadLine());
    int[] parent = Enumerable.Range(0, n).ToArray();
    var lst = new List<(int x, int y, int distance)>();
    for (int j = 0; j < n; j++)
    {
        var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        lst.Add((inputs[0], inputs[1], inputs[2]));
    }

    for (var j = 0; j < n; j++)
    {
        var current = lst[j];
        var x = current.x;
        var y = current.y;
        var distance = current.distance;
        for (int index = j + 1; index < lst.Count; index++)
        {
            var diff = (lst[index].x - x) * (lst[index].x - x) + (lst[index].y - y) * (lst[index].y - y);
            var sumDistance = distance + lst[index].distance;
            if (sumDistance * sumDistance >= diff)
            {
                Union(index, j);
            }
        }
    }

    var group = new List<int>();
    int result = 0;
    for (int checkIndex = 0; checkIndex < n; checkIndex++)
    {
        var x = FindParent(checkIndex);
        if (group.Contains(x)) continue;
        group.Add(x);
        result++;
    }

    void Union(int left, int right)
    {
        var leftParent = FindParent(left);
        var rightParent = FindParent(right);
        if (leftParent > rightParent) parent[leftParent] = rightParent;
        else parent[rightParent] = leftParent;
    }

    int FindParent(int x)
    {
        if (x == parent[x]) return x;
        return FindParent(parent[x]);
    }

    sw.WriteLine(result);
}

sw.Flush();
sw.Close();
sr.Close();