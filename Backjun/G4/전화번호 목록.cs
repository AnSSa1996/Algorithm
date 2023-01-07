var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());
for (var t = 0; t < T; t++)
{
    var N = int.Parse(sr.ReadLine());
    var pLst = new List<string>();
    for (var n = 0; n < N; n++)
    {
        pLst.Add(sr.ReadLine());
    }

    pLst.Sort();

    var check = true;
    for (var next = 1; next < N; next++)
    {
        var left = pLst[next - 1];
        var right = pLst[next];
        if (left.Length > right.Length) continue;

        var isSame = true;
        for (var index = 0; index < left.Length; index++)
        {
            if (left[index] == right[index]) continue;
            isSame = false;
            break;
        }

        if (isSame)
        {
            check = false;
            break;
        }
    }

    sw.WriteLine(check ? "YES" : "NO");
}

sr.Close();
sw.Close();