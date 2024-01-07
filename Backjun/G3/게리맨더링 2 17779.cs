StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());               // 재현시 의 크기
var A = new int[N, N];                            // 재현시의 지형 정보

for (var i = 0; i < N; i++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var j = 0; j < N; j++)
    {
        A[i, j] = inputs[j];
    }
}

var result = int.MaxValue;
for (var d1 = 1; d1 < N; d1++)
{
    for (var d2 = 1; d2 < N; d2++)
    {
        for (var x = 1; x < N; x++)
        {
            for (var y = 1; y < N; y++)
            {
                if (x + d1 + d2 >= N) continue;
                if (y - d1 < 0) continue;
                if (y + d2 >= N) continue;

                var district = new int[5];
                
                for(var c = 0; c < N; c++)
                {
                    for(var r = 0; r < N; r++)
                    {
                        if (r < x + d1 && c <= y && (r >= x && c >= y - (r - x)) == false) district[0] += A[r, c];
                        else if (r <= x + d2 && c > y && (r >= x && c <= y + (r - x)) == false) district[1] += A[r, c];
                        else if (r >= x + d1 && c < y - d1 + d2 && (r <= x + d1 + d2 && c >= (y - d1 + d2) - (x + d1 + d2 - r)) == false) district[2] += A[r, c];
                        else if (r > x + d2 && c >= y - d1 + d2 && (r <= x + d1 + d2 && c <= (y - d1 + d2) + (x + d1 + d2 - r)) == false) district[3] += A[r, c];
                        else district[4] += A[r, c];
                    }
                }
                
                var max = district.Max();
                var min = district.Min();
                
                if (result > max - min) result = max - min;
            }
        }
    }
}

sw.WriteLine(result);
sw.Close();
sr.Close();