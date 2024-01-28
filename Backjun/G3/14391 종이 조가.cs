var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

var Y = inputs[0]; // 세로의 크기
var X = inputs[1]; // 가로의 크기

var map = new int[Y, X];
for (var i = 0; i < Y; i++)
{
    var line = sr.ReadLine();
    for (var j = 0; j < X; j++)
    {
        map[i, j] = line[j] - '0';
    }
}

var answer = 0;

var repeat = 1 << (X * Y);

for (var i = 0; i < repeat; i++)
{
    var temp = 0;
    for (var y = 0; y < Y; y++)
    {
        var sum = 0;
        for (var x = 0; x < X; x++)
        {
            var index = y * X + x;
            if ((i & (1 << index)) != 0)
            {
                sum *= 10;
                sum += map[y, x];
            }
            else
            {
                temp += sum;
                sum = 0;
            }
        }

        temp += sum;
    }

    for (var x = 0; x < X; x++)
    {
        var sum = 0;
        for (var y = 0; y < Y; y++)
        {
            var index = y * X + x;
            if ((i & (1 << index)) == 0)
            {
                sum *= 10;
                sum += map[y, x];
            }
            else
            {
                temp += sum;
                sum = 0;
            }
        }

        temp += sum;
    }

    answer = Math.Max(answer, temp);
}

sw.WriteLine(answer);
sw.Close();
sr.Close();