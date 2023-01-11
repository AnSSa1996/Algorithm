using Microsoft.VisualBasic;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];

var parent = Enumerable.Range(0, N + 1).ToArray();
var knowPeople = new bool[N + 1];
inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
for (var index = 1; index < inputs.Length; index++) knowPeople[inputs[index]] = true;

var PartyPeople = new List<List<int>>();

for (var i = 0; i < M; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    inputs = inputs[1..];
    var current = inputs[0];
    for (var index = 1; index < inputs.Length; index++)
    {
        var next = inputs[index];
        Union(current, next);
        current = next;
    }

    PartyPeople.Add(inputs.ToList());
}

var count = 0;
foreach (var peoples in PartyPeople)
{
    var check = true;
    foreach (var people in peoples)
    {
        var p = FindParent(people);
        if (knowPeople[p])
        {
            check = false;
            break;
        }
    }

    if (check) count++;
}

sw.WriteLine(count);

int FindParent(int x)
{
    return parent[x] == x ? x : FindParent(parent[x]);
}

void Union(int left, int right)
{
    left = FindParent(left);
    right = FindParent(right);
    if (left == right) return;
    if (knowPeople[left] || knowPeople[right])
    {
        knowPeople[left] = true;
        knowPeople[right] = true;
    }

    if (left < right)
    {
        parent[right] = left;
    }

    if (right < left)
    {
        parent[left] = right;
    }
}

sr.Close();
sw.Close();