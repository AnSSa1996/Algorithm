var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());       // 용액의 갯수
var solutionList = Array.ConvertAll(sr.ReadLine().Split(' '), long.Parse).ToList(); // 용액의 특성 값
solutionList.Sort();                    // 용액의 특성 값 정렬

long answer = long.MaxValue;
var answerList = new List<long>();
for (var index = 0; index < solutionList.Count; index++)
{
    var current = solutionList[index];

    var left = 0;
    var right = solutionList.Count - 1;
    while (left < right)
    {
        if (left == index)
        {
            left++;
            continue;
        }

        if (right == index)
        {
            right--;
            continue;
        }

        long sum = current + solutionList[left] + solutionList[right];
        if (Math.Abs(sum) < answer)
        {
            answer = Math.Abs(sum);
            answerList = new List<long> { current, solutionList[left], solutionList[right] };
        }

        if (sum == 0)
        {
            break;
        }
        if (sum < 0)
        {
            left++;
        }
        else
        {
            right--;
        }
    }

    if (answer == 0)
    {
        break;
    }
}

sw.WriteLine(string.Join(" ", answerList));
sr.Close();
sw.Close();