var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var N = int.Parse(sr.ReadLine());
var arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
Array.Sort(arr);

var result = 1;

for (var i = 0; i < N; i++)
{
    if (result < arr[i]) break;
    result += arr[i];
}

sw.WriteLine(result);
sw.Close();
sr.Close();