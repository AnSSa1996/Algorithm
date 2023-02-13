5 4 100
1 1 1 1 1
1 5
2 4
4 3
5 4var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];
var K = inputs[2];

var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var parent = Enumerable.Range(0, N).ToArray();

for (var n = 0; n < M; n++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var left = inputs[0] - 1;
    var right = inputs[1] - 1;
    Union(left, right);
}

long value = 0;
for (var n = 0; n < N; n++)
{
    if (n != FindParent(n)) continue;
    value += nums[n];
}

if (value <= K) sw.WriteLine(value);
else sw.WriteLine("Oh no");

int FindParent(int x)
{
    return x == parent[x] ? x : parent[x] = FindParent(parent[x]);
}

void Union(int left, int right)
{
    left = FindParent(left);
    right = FindParent(right);
    if (nums[left] <= nums[right]) parent[right] = left;
    if (nums[right] < nums[left]) parent[left] = right;
}


sw.Flush();
sw.Close();
sr.Close();