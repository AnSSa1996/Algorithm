var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var a1 = input[0];
var a0 = input[1];

var c = int.Parse(sr.ReadLine());
var k = int.Parse(sr.ReadLine());

var result = true;

var fn = a1*k + a0;
var gn = c * k;

if (fn <= gn && a1 <= c)
{
    result = true;
}
else
{
    result = false;
}

sw.WriteLine(result ? 1 : 0);
sr.Close();
sw.Close();
