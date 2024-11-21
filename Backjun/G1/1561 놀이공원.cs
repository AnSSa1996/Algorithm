var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var N = inputs[0];
var M = inputs[1];

var rideList = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
var time = GetTime(N, M, rideList, 100000);

if (time == 0)
{
    sw.WriteLine(N);
}
else
{
    sw.WriteLine(GetLastRide(N, M, rideList, time));
}

sr.Close();
sw.Close();

long GetTime(int N, int M, int[] rideTimes, int maxPt)
{
    long left = 0;
    long right = (long)rideTimes.Max() * N;
    long time = 0;

    while (left <= right)
    {
        long mid = (left + right) / 2;
        long riderCount = GetRiderCount(rideTimes, mid, M);

        if (riderCount >= N)
        {
            time = mid;
            right = mid - 1;
        }
        else
        {
            left = mid + 1;
        }
    }

    return time;
}


long GetRiderCount(int[] rideTimes, long time, int M)
{
    long sum = M;
    foreach (int rideTime in rideTimes)
    {
        sum += time / rideTime;
    }
    return sum;
}

int GetLastRide(int N, int M, int[] rideTimes, long time)
{
    var riderCount = GetRiderCount(rideTimes, time - 1, M);
    for (int i = 0; i < M; i++)
    {
        if (time % rideTimes[i] == 0)
        {
            riderCount++;
            if (riderCount == N)
            {
                return i + 1;
            }
        }
    }

    return -1;
}