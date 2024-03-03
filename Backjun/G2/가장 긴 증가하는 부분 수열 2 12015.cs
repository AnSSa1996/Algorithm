var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var N = int.Parse(sr.ReadLine());       // 수열의 길이
var sequenceArray = Array.ConvertAll(sr.ReadLine().Split(), int.Parse); // 수열
var memorization = new List<int>();
memorization.Add(0);

foreach (var num in sequenceArray)
{
    var finalValue = memorization.Last();
    if (finalValue < num)
    {
        memorization.Add(num);
    }
    else
    {
        var index = memorization.BinarySearch(num);
        if (index < 0)
        {
            index = ~index;
        }
        memorization[index] = num;
    }
}

sw.WriteLine(memorization.Count - 1);
sw.Close();
sr.Close();