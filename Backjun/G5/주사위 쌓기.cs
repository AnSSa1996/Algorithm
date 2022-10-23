StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int N = int.Parse(sr.ReadLine());
List<int[]> dice = new List<int[]>();
for (int i = 0; i < N; i++)
{
    dice.Add(Array.ConvertAll(sr.ReadLine().Split(), int.Parse));
}

int maxResult = 0;
int result = 0;
for (int i = 0; i < 6; i++)
{
    result = 0;
    DiceResult(dice[0][i], 1);
}

sw.WriteLine(maxResult);

void DiceResult(int currentValue, int count)
{
    var index = 0;
    for (int i = 0; i < 6; i++)
    {
        if (dice[count - 1][i] == currentValue)
        {
            index = i;
            break;
        }
    }

    var upIndex = 0;
    if (index == 0) upIndex = 5;
    else if (index == 1) upIndex = 3;
    else if (index == 2) upIndex = 4;
    else if (index == 3) upIndex = 1;
    else if (index == 4) upIndex = 2;
    else if (index == 5) upIndex = 0;

    var currentMax = 0;
    for (var i = 0; i < 6; i++)
    {
        if (i == index || i == upIndex) continue;
        currentMax = Math.Max(dice[count - 1][i], currentMax);
    }

    result += currentMax;
    if (count == N)
    {
        maxResult = Math.Max(maxResult, result);
        return;
    }

    DiceResult(dice[count - 1][upIndex], count + 1);
}


sw.Flush();
sw.Close();
sr.Close();