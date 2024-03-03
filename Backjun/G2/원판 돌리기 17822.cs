var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];
var T = inputs[2];

var roundSpinDict = new Dictionary<int, RoundSpin>();
for (var i = 0; i < N; i++)
{
    var nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    roundSpinDict[i + 1] = new RoundSpin(nums);
}

for (var t = 0; t < T; t++)
{
    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var x = inputs[0];
    var d = inputs[1];
    var k = inputs[2];
    Spin(x, d, k);
    Perform();
}

void Spin(int x, int d, int k)
{
    for (var i = 1; i <= N; i++)
    {
        if (i % x != 0) continue;
        if (d == 0)
        {
            roundSpinDict[i].Clockwise(k);
        }
        else
        {
            roundSpinDict[i].CounterClockwise(k);
        }
    }
}

void Perform()
{
    if (RemoveSameNum()) return;
    AddOrSubtract();
}

bool RemoveSameNum()
{
    var removeList = new List<(int, int)>();
    for (var i = 1; i <= N; i++)
    {
        for (var j = 0; j < M; j++)
        {
            var num = roundSpinDict[i].nums[j];
            if (num == 0) continue;
            if (j == M - 1)
            {
                if (num == roundSpinDict[i].nums[0])
                {
                    removeList.Add((i, j));
                    removeList.Add((i, 0));
                }
            }
            else
            {
                if (num == roundSpinDict[i].nums[j + 1])
                {
                    removeList.Add((i, j));
                    removeList.Add((i, j + 1));
                }
            }
            
            if (i == N) continue;
            if (num == roundSpinDict[i + 1].nums[j])
            {
                removeList.Add((i, j));
                removeList.Add((i + 1, j));
            }
        }
    }
    
    if (removeList.Count == 0) return false;
    foreach (var (x, y) in removeList)
    {
        RemoveNum(x, y);
    }
    return true;
}

void RemoveNum(int x, int y)
{
    roundSpinDict[x].nums[y] = 0;
}

void AddOrSubtract()
{
    var sum = 0;
    var count = 0;
    for (var i = 1; i <= N; i++)
    {
        for (var j = 0; j < M; j++)
        {
            if (roundSpinDict[i].nums[j] == 0) continue;
            sum += roundSpinDict[i].nums[j];
            count++;
        }
    }

    if (count == 0) return;
    var avg = (float)sum / count;
    for (var i = 1; i <= N; i++)
    {
        for (var j = 0; j < M; j++)
        {
            if (roundSpinDict[i].nums[j] == 0) continue;
            if (roundSpinDict[i].nums[j] > avg)
            {
                roundSpinDict[i].nums[j]--;
            }
            else if (roundSpinDict[i].nums[j] < avg)
            {
                roundSpinDict[i].nums[j]++;
            }
        }
    }
}

int Sum()
{
    var sum = 0;
    for (var i = 1; i <= N; i++)
    {
        for (var j = 0; j < M; j++)
        {
            sum += roundSpinDict[i].nums[j];
        }
    }

    return sum;
}

sw.WriteLine(Sum());
sw.Close();
sr.Close();

public class RoundSpin
{
    public int[] nums;

    public RoundSpin(int[] nums)
    {
        this.nums = nums;
    }

    public void Clockwise(int count)
    {
        var temp = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            temp[(i + count) % nums.Length] = nums[i];
        }

        nums = temp;
    }

    public void CounterClockwise(int count)
    {
        var temp = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            temp[(i - count + nums.Length) % nums.Length] = nums[i];
        }
        nums = temp;
    }
}