var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var N = int.Parse(sr.ReadLine());
var arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var list = new List<int>();

for (var index = 0; index < arr.Length; index++)
{
    if (list.Count == 0)
    {
        list.Add(arr[index]);
        continue;
    }

    var last = list.Last();
    if (last < arr[index])
    {
        list.Add(arr[index]);
    }
    else
    {
        var binaryIndex = list.BinarySearch(arr[index]);
        if (binaryIndex < 0)
        {
            binaryIndex = ~binaryIndex;
        }

        list[binaryIndex] = arr[index];
    }
}

sw.WriteLine(list.Count);
sw.Close();
sr.Close();