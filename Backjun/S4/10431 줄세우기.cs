var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var P = int.Parse(sr.ReadLine());
for (var p = 0; p < P; p++)
{
    var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var N = inputs[0];
    var nums = inputs[1..];
    var students = new int[20];

    for (var i = 0; i < 20; i++)
    {
        students[i] = nums[i];
    }

    var moves = 0;

    for (var i = 1; i < 20; i++)
    {
        var current = students[i];
        var j = i - 1;

        while (j >= 0 && students[j] > current)
        {
            students[j + 1] = students[j];
            j--;
            moves++;
        }

        students[j + 1] = current;
    }

    sw.WriteLine($"{N} {moves}");
}

sw.Close();
sr.Close();