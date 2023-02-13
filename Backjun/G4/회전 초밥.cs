using System.Xml;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var D = inputs[1];
var K = inputs[2];
var C = inputs[3];

var board = new int[N];
for (var n = 0; n < N; n++)
    board[n] = int.Parse(sr.ReadLine());

var left = 0;
var right = 0;

var dict = new Dictionary<int, int>();
dict.Add(C, 1);

while (right < K)
{
    if (dict.ContainsKey(board[right]))
    {
        dict[board[right]]++;
    }
    else
    {
        dict.Add(board[right], 1);
    }

    right++;
}

var result = 0;
var count = dict.Count(x => x.Value > 0);
while (left < N)
{
    result = Math.Max(result, count);
    dict[board[left]]--;
    if (dict[board[left]] == 0) count--;
    right %= N;
    if (dict.ContainsKey(board[right]))
    {
        dict[board[right]]++;
    }
    else
    {
        dict.Add(board[right], 1);
    }

    if (dict[board[right]] == 1) count++;

    left += 1;
    right += 1;
}

sw.WriteLine(result);

sw.Flush();
sw.Close();
sr.Close();