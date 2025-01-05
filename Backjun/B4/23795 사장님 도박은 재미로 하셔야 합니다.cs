var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var sum = 0L;

while (true)
{
    var num = long.Parse(sr.ReadLine());
    if(num == -1) break;
    sum += num;
}

sw.WriteLine(sum);
sw.Close();
sr.Close();