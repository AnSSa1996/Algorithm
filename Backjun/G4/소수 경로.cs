using Microsoft.VisualBasic;

var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var T = int.Parse(sr.ReadLine());
var sosu = new bool[10000];
sosu[0] = true;
sosu[1] = true;
eratos();

void eratos()
{
    for (var i = 2; i <= 100; i++)
    {
        if (sosu[i]) continue;
        for (var j = i * 2; j < 10000; j += i)
        {
            sosu[j] = true;
        }
    }
}

for (var t = 0; t < T; t++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var left = inputs[0];
    var right = inputs[1];
    var result = -1;

    BFS();
    if (result == -1) sw.WriteLine("Impossible");
    else sw.WriteLine(result);

    void BFS()
    {
        var visited = new bool[10000];
        Queue<(List<int> num, int cnt)> q = new Queue<(List<int> num, int cnt)>();
        var leftString = left.ToString();
        var first = new List<int>();
        for (var digit = 0; digit < 4; digit++)
        {
            first.Add(leftString[digit] - '0');
        }

        q.Enqueue((first, 0));

        while (q.Count > 0)
        {
            var current = q.Dequeue();
            var num = current.num;
            var count = current.cnt;

            var currentNum = 0;
            var m = 1000;
            for (var d = 0; d < 4; d++)
            {
                currentNum += num[d] * m;
                m /= 10;
            }

            if (currentNum == right)
            {
                result = count;
                break;
            }

            for (var digit = 0; digit < 4; digit++)
            {
                var temp = num[digit];
                for (var nextNum = 0; nextNum <= 9; nextNum++)
                {
                    if (digit == 0 && nextNum == 0) continue;
                    num[digit] = nextNum;
                    var numInt = 0;
                    var multiply = 1000;
                    for (var d = 0; d < 4; d++)
                    {
                        numInt += num[d] * multiply;
                        multiply /= 10;
                    }

                    if (sosu[numInt]) continue;
                    if (visited[numInt]) continue;
                    visited[numInt] = true;
                    q.Enqueue((num.ToList(), count + 1));
                }

                num[digit] = temp;
            }
        }
    }
}

sr.Close();
sw.Close();