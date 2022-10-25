using System.ComponentModel.Design;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Xml.XPath;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var result = new List<int>();
var combinations = new List<(int X, int Y)>();
for (int i = 0; i < 6; i++)
{
    for (int j = i + 1; j < 6; j++)
    {
        combinations.Add((i, j));
    }
}

var winArrary = new int[6];
var drawArrary = new int[6];
var loseArrary = new int[6];

var ans = 0;
for (var T = 0; T < 4; T++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (int j = 0; j < 6; j++)
    {
        winArrary[j] = inputs[j * 3];
        drawArrary[j] = inputs[j * 3 + 1];
        loseArrary[j] = inputs[j * 3 + 2];
    }

    ans = 0;
    DFS();
    result.Add(ans);
}

void DFS(int count = 0)
{
    if (count == 15)
    {
        if (winArrary.Sum() == 0 && drawArrary.Sum() == 0 && drawArrary.Sum() == 0)
        {
            ans = 1;
        }

        return;
    }

    var X = combinations[count].X;
    var Y = combinations[count].Y;

    // 이겼을 때
    if (winArrary[X] > 0 && loseArrary[Y] > 0)
    {
        winArrary[X] -= 1;
        loseArrary[Y] -= 1;
        DFS(count + 1);
        winArrary[X] += 1;
        loseArrary[Y] += 1;
    }

    // 졌을 때
    if (loseArrary[X] > 0 && winArrary[Y] > 0)
    {
        loseArrary[X] -= 1;
        winArrary[Y] -= 1;
        DFS(count + 1);
        loseArrary[X] += 1;
        winArrary[Y] += 1;
    }

    // 비겼을 때
    if (drawArrary[X] > 0 && drawArrary[Y] > 0)
    {
        drawArrary[X] -= 1;
        drawArrary[Y] -= 1;
        DFS(count + 1);
        drawArrary[X] += 1;
        drawArrary[Y] += 1;
    }
}

sw.WriteLine(string.Join(" ", result));

sw.Flush();
sw.Close();
sr.Close();