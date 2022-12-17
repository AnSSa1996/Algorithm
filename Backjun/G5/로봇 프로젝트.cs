var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

while (true)
{
    string str = sr.ReadLine();
    if(string.IsNullOrEmpty(str)) break;
    var C = int.Parse(str);
    C = C * 10000000;

    var numLst = new List<int>();
    var numCount = int.Parse(sr.ReadLine());
    for (var index = 0; index < numCount; index++)
    {
        numLst.Add(int.Parse(sr.ReadLine()));
    }

    numLst.Sort();

    var left = 0;
    var right = numCount - 1;
    var check = false;
    while (left < right)
    {
        var sum = numLst[left] + numLst[right];
        if (sum < C)
        {
            left++;
        }
        else if (sum > C)
        {
            right--;
        }
        else if (sum == C)
        {
            check = true;
            break;
        }
    }

    sw.WriteLine(check ? $"yes {numLst[left]} {numLst[right]}" : $"danger");
}

sw.Close();
sr.Close();