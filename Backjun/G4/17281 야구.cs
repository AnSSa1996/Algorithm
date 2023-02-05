using System.Text.Encodings.Web;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var permutation = new Permutation<int>();
var array = new int[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
var result = permutation.permutate(array).Where(x => x[3] == 0).ToList();

var N = int.Parse(sr.ReadLine());

var total = 0;
var numsList = new List<int[]>();
for (var i = 0; i < N; i++)
{
    var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    numsList.Add(nums);
}

var max = 0;
foreach (var nextArray in result)
{
    Check(nextArray);
}

sw.WriteLine(max);

void Check(int[] orderArray)
{
    var order = 0;
    var score = 0;
    foreach (var nums in numsList)
    {
        var first = 0;
        var second = 0;
        var third = 0;
        var outCount = 0;
        while (outCount < 3)
        {
            if (order == 9) order = 0;
            var current = nums[orderArray[order++]];

            if (current == 0)
            {
                outCount++;
                continue;
            }

            if (current == 1)
            {
                score += third;
                third = second;
                second = first;
                first = 1;
            }

            if (current == 2)
            {
                score += third + second;
                third = first;
                second = 1;
                first = 0;
            }

            if (current == 3)
            {
                score += third + second + first;
                third = 1;
                second = 0;
                first = 0;
            }

            if (current == 4)
            {
                score += 1 + first + second + third;
                third = 0;
                second = 0;
                first = 0;
            }
        }
    }

    max = Math.Max(max, score);
}

sw.Flush();
sw.Close();
sr.Close();

public class Permutation<T>
{
    List<T[]> permutated_items = new List<T[]>();
    bool start = true;

    private List<T[]> perm(int n, T[] array)
    {
        if (n == 1)
        {
            permutated_items.Add(((T[])array.Clone()));
        }

        else
        {
            for (int i = 0; i < n - 1; i++)
            {
                perm(n - 1, array);
                if (n % 2 == 0)
                {
                    swap(ref array[i], ref array[n - 1]);
                }
                else
                {
                    swap(ref array[0], ref array[n - 1]);
                }
            }

            perm(n - 1, array);
        }

        start = false;
        return permutated_items;
    }

    public List<T[]> permutate(params T[] array)
    {
        List<T[]> result = perm(array.Length, array);
        permutated_items = new List<T[]>();
        return result;
    }

    private static void swap(ref T x, ref T y)
    {
        T temp = x;
        x = y;
        y = temp;
    }
}