var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var T = int.Parse(sr.ReadLine());

for (var t = 0; t < T; t++)
{
    var N = int.Parse(sr.ReadLine());
    var nameDict = new Dictionary<string, (string, int)>(); // (parent, count)

    for (var n = 0; n < N; n++)
    {
        var names = sr.ReadLine().Split(' ');
        var left = names[0];
        var right = names[1];
        var count = Union(left, right);
        sw.WriteLine(count);
    }

    int Union(string a, string b)
    {
        var rootA = Find(a);
        var rootB = Find(b);
        
        if (rootA == rootB)
        {
            return nameDict[rootA].Item2;
        }

        var first = rootA.CompareTo(rootB) < 0 ? rootA : rootB;
        var second = rootA.CompareTo(rootB) < 0 ? rootB : rootA;
        
        nameDict[first] = (first, nameDict[first].Item2 + nameDict[second].Item2);
        nameDict[second] = (first, 0);
        
        return nameDict[first].Item2;
    }
    
    string Find(string name)
    {
        if (nameDict.ContainsKey(name) == false)
        {
            nameDict[name] = (name, 1);
            return name;
        }
        
        if (nameDict[name].Item1 == name)
        {
            return name;
        }
        else
        {
            return Find(nameDict[name].Item1);
        }
    }
}

sw.Close();
sr.Close();