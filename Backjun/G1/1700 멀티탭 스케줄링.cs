var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var K = inputs[1];

var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var plugList = new List<int>();
var changeCount = 0;
for (var index = 0; index < K; index++)
{
    if (plugList.Contains(nums[index]))
    {
        continue;
    }

    if (plugList.Count < N)
    {
        plugList.Add(nums[index]);
        continue;
    }

    var plugIndex = 0;
    var maxIndex = 0;
    for (var i = 0; i < N; i++)
    {
        var plugNum = plugList[i];
        var nextIndex = index + 1;
        while (nextIndex < K)
        {
            if (nums[nextIndex] == plugNum)
            {
                break;
            }
            
            nextIndex++;
        }

        if (nextIndex > maxIndex)
        {
            maxIndex = nextIndex;
            plugIndex = i;
        }
    }
    
    plugList[plugIndex] = nums[index];
    changeCount++;
}

sw.WriteLine(changeCount);
sr.Close();
sw.Close();