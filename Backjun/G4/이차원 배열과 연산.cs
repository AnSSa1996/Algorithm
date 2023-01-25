StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var r = inputs[0];
var c = inputs[1];
var k = inputs[2];

var array = new int[3, 3];
var count = 0;
var result = -1;

for (var i = 0; i < 3; i++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (var j = 0; j < 3; j++)
    {
        array[i, j] = inputs[j];
    }
}

while (count <= 100)
{
    var R_Length = array.GetLength(0);
    var C_Length = array.GetLength(1);
    if (R_Length >= r && C_Length >= c)
    {
        if (array[r - 1, c - 1] == k)
        {
            result = count;
            break;
        }
    }

    count++;

    if (R_Length >= C_Length)
    {
        var max = 0;
        var arrayList = new List<List<int>>();
        for (var row = 0; row < R_Length; row++)
        {
            var temp = new List<int>();
            var currentArray = CustomArray<int>.GetRow(array, row);
            var group = currentArray.Where(x => x > 0).GroupBy(a => a).Select(b => new
            {
                key = b.Key,
                count = b.Count()
            }).OrderBy(c => c.count).ThenBy(d => d.key);

            foreach (var pair in group)
            {
                temp.Add(pair.key);
                temp.Add(pair.count);
            }

            max = Math.Max(max, temp.Count);
            arrayList.Add(temp);
        }

        array = new int[R_Length, max];
        var y = 0;
        foreach (var currentArray in arrayList)
        {
            var x = 0;
            foreach (var value in currentArray)
            {
                array[y, x++] = value;
            }

            y++;
        }
    }
    else
    {
        var max = 0;
        var arrayList = new List<List<int>>();
        for (var column = 0; column < C_Length; column++)
        {
            var temp = new List<int>();
            var currentArray = CustomArray<int>.GetColumn(array, column);
            var group = currentArray.Where(x => x > 0).GroupBy(a => a).Select(b => new
            {
                key = b.Key,
                count = b.Count()
            }).OrderBy(c => c.count).ThenBy(d => d.key);

            foreach (var pair in group)
            {
                temp.Add(pair.key);
                temp.Add(pair.count);
            }

            max = Math.Max(max, temp.Count);
            arrayList.Add(temp);
        }

        array = new int[max, C_Length];

        var x = 0;
        foreach (var currentArray in arrayList)
        {
            var y = 0;
            foreach (var value in currentArray)
            {
                array[y++, x] = value;
            }

            x++;
        }
    }
}

sw.WriteLine(result);

sw.Flush();
sw.Close();
sr.Close();

public static class CustomArray<T>
{
    public static T[] GetColumn(T[,] matrix, int columnNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(0))
            .Select(x => matrix[x, columnNumber])
            .ToArray();
    }

    public static T[] GetRow(T[,] matrix, int rowNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(1))
            .Select(x => matrix[rowNumber, x])
            .ToArray();
    }
}