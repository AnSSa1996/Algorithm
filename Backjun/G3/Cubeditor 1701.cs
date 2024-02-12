var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var originString = sr.ReadLine();
int[] KMP(string pattern)
{
    var pi = new int[pattern.Length];
    var patternLength = pattern.Length;
    var j = 0;
    for (var i = 1; i < patternLength; i++)
    {
        while (j > 0 && pattern[i] != pattern[j])
        {
            j = pi[j - 1];
        }

        if (pattern[i] == pattern[j])
        {
            if (j == pattern.Length - 1)
            {
                j = pi[j];
            }
            else
            {
                pi[i] = ++j;
            }
        }
    }

    return pi;
}

var max = 0;
for (var i = 0; i < originString.Length; i++)
{
    var pi = KMP(originString.Substring(i));
    max = Math.Max(max, pi.Max());
}

sw.WriteLine(max);
sw.Close();
sr.Close();