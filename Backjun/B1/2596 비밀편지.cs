using System.Text;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var codeMapping = new Dictionary<string, char>
{
    { "000000", 'A' },
    { "001111", 'B' },
    { "010011", 'C' },
    { "011100", 'D' },
    { "100110", 'E' },
    { "101001", 'F' },
    { "110101", 'G' },
    { "111010", 'H' }
};

var N = int.Parse(sr.ReadLine());
var message = sr.ReadLine();
var result = new StringBuilder();
var error = false;
var errorIndex = -1;
for (var n = 0; n < N; n++)
{
    var code = message.Substring(n * 6, 6);
    error = true;
    foreach (var codeKey in codeMapping)
    {
        if (GetHammingDistance(code, codeKey.Key) <= 1)
        {
            error = false;
            result.Append(codeKey.Value);
            break;
        }
    }

    if (error)
    {
        errorIndex = n + 1;
        break;
    }
}


if (errorIndex != -1)
{
    sw.WriteLine(errorIndex);
}
else
{
    sw.WriteLine(result.ToString());
}

sw.Close();
sr.Close();

static int GetHammingDistance(string str1, string str2)
{
    int distance = 0;

    for (int i = 0; i < str1.Length; i++)
    {
        if (str1[i] != str2[i])
            distance++;
    }

    return distance;
}