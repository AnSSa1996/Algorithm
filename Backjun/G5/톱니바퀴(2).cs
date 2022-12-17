var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var gearCount = int.Parse(sr.ReadLine());
var Gear = new List<List<int>>();
for (int i = 0; i < gearCount; i++)
{
    Gear.Add(sr.ReadLine().Select(x => x - '0').ToList());
}

var N = int.Parse(sr.ReadLine());

for (int i = 0; i < N; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var gear = inputs[0] - 1;
    var dir = inputs[1];
    Check(gear, dir, 0);
}

var result = 0;

for (var i = 0; i < gearCount; i++)
{
    if (Gear[i][0] == 1) result += 1;
}

sw.WriteLine(result);

void Check(int G, int direction, int which)
{
    switch (which)
    {
        case -1:
            if (G - 1 >= 0 && Gear[G][6] != Gear[G - 1][2])
            {
                Check(G - 1, direction * -1, -1);
            }

            break;
        case 1:
            if (G + 1 < gearCount && Gear[G][2] != Gear[G + 1][6])
            {
                Check(G + 1, direction * -1, 1);
            }

            break;
        case 0:
            if (G + 1 < gearCount && Gear[G][2] != Gear[G + 1][6])
            {
                Check(G + 1, direction * -1, 1);
            }

            if (G - 1 >= 0 && Gear[G][6] != Gear[G - 1][2])
            {
                Check(G - 1, direction * -1, -1);
            }

            break;
    }

    Rotation(G, direction);
}

void Rotation(int G, int d)
{
    if (d == 1)
    {
        int temp = Gear[G][7];
        for (int i = 7; i > 0; i--)
        {
            Gear[G][i] = Gear[G][i - 1];
        }

        Gear[G][0] = temp;
    }
    else
    {
        int temp = Gear[G][0];
        for (int i = 0; i < 7; i++)
        {
            Gear[G][i] = Gear[G][i + 1];
        }

        Gear[G][7] = temp;
    }
}

sw.Flush();
sw.Close();
sr.Close();