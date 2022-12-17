var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());

for (var t = 0; t < T; t++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var num = inputs[0];
    var parent = inputs[1];
    while (true)
    {
        var x = herry(num, parent);
        if (num * x == parent)
        {
            sw.WriteLine(x);
            break;
        }

        num = num * x - parent;
        parent = parent * x;
    }
}

int herry(int num, int parent)
{
    var n = parent / num;
    if (n * num >= parent)
        return n;
    return n + 1;
}

sr.Close();
sw.Close();