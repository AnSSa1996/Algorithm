var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

while (true)
{
    var N = int.Parse(sr.ReadLine());
    if (N == 0) break;
    
    var realStringList = new List<string>();
    var stringList = new List<(string str, int index)>();
    
    for (var i = 0; i < N; i++)
    {
        var str = sr.ReadLine();
        realStringList.Add(str);
        str = str.ToLower();
        stringList.Add((str, i));
    }
    
    stringList.Sort((a, b) =>
    {
        if (a.str == b.str) return a.index.CompareTo(b.index);
        return a.str.CompareTo(b.str);
    });
    
    sw.WriteLine(realStringList[stringList[0].index]);
}

sr.Close();
sw.Close();