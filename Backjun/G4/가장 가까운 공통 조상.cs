using System.Xml;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());
for (var t = 0; t < T; t++)
{
    var N = int.Parse(sr.ReadLine());
    var parent = new int[N + 1];
    for (var i = 0; i < N - 1; i++)
    {
        var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        var a = inputs[0];
        var b = inputs[1];
        parent[b] = a;
    }

    var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var left = input[0];
    var right = input[1];

    var leftList = new List<int>();
    leftList.Add(0);
    leftList.Add(left);
    while (parent[left] != 0)
    {
        leftList.Add(parent[left]);
        left = parent[left];
    }

    var leftLevel = leftList.Count - 1;

    var rightList = new List<int>();
    rightList.Add(0);
    rightList.Add(right);
    while (parent[right] != 0)
    {
        rightList.Add(parent[right]);
        right = parent[right];
    }

    var rightLevel = rightList.Count - 1;

    while (leftList[leftLevel] == rightList[rightLevel])
    {
        leftLevel--;
        rightLevel--;
    }

    sw.WriteLine(leftList[leftLevel + 1]);
}

sw.Flush();
sw.Close();
sr.Close();