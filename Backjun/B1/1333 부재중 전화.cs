var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var L = inputs[1];
var D = inputs[2];

var total = N * L + (N - 1) * 5;
var song = new bool[total + 1];

for(var i = 0; i <= total; i += L + 5)
{
    for (var j = i; j < i + L; j++)
    {
        song[j] = true;
    }
}

var time = 0;
for (var i = 0; i <= total; i += D)
{
    if (song[i]) continue;
    time = i;
    break;
}

if (time == 0)
{
    time = total + (D - total % D);
}

sw.WriteLine(time);

sw.Close();
sr.Close();