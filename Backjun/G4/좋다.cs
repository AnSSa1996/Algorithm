StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());
var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
Array.Sort(nums);

var result = 0;
for (var i = 0; i < N; i++)
{
    if (Search(i)) result++;
}

sw.WriteLine(result);

bool Search(int searchIndex)
{
    var start = 0;
    var end = N - 1;
    var check = false;
    var searchNum = nums[searchIndex];
    while (start < end)
    {
        if (start == searchIndex)
        {
            start++;
            continue;
        }

        if (end == searchIndex)
        {
            end--;
            continue;
        }
        
        var mid = nums[start] + nums[end];

        if (mid == searchNum)
        {
            check = true;
            break;
        }

        if (mid < searchNum)
        {
            start++;
        }
        else
        {
            end--;
        }
    }

    return check;
}

sw.Flush();
sw.Close();
sr.Close();