var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var N = int.Parse(sr.ReadLine());
var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var numList = new List<int>();

for(var i = 0; i < N; i++)
{
    if(numList.Count == 0)
    {
        numList.Add(nums[i]);
    }
    else
    {
        if(numList[^1] < nums[i])
        {
            numList.Add(nums[i]);
        }
        else
        {
            var index = numList.BinarySearch(nums[i]);
            if(index < 0)
            {
                index = ~index;
            }
            numList[index] = nums[i];
        }
    }
}

sw.WriteLine(numList.Count);
sw.Close();
sr.Close();