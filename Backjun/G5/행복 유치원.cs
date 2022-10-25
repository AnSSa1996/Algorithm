var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var n = inputs[0];
var k = inputs[1];

inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
List<int> diffList = new();
for (int i = 1; i < n; i++)
{
    diffList.Add(inputs[i] - inputs[i - 1]);
}

diffList.Sort((a, b) => b - a);
var diffArray = diffList.ToArray();
var sum = diffArray[(k - 1)..].Sum();
sw.WriteLine(sum);

sw.Flush();
sw.Close();
sr.Close();