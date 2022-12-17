var sr = new StreamReader(Console.OpenStandardInput());
var sw = new StreamWriter(Console.OpenStandardOutput());

var N = int.Parse(sr.ReadLine());

var sum = 3;
var length = 3;

while (N > sum)
{
    length += 1;
    sum = sum * 2 + length;
}

char Recursive(int currentSum, int currentLength, int currentIndex)
{
    var prevSum = (currentSum - currentLength) / 2;
    if (currentIndex <= prevSum)
    {
        return Recursive(prevSum, currentLength - 1, currentIndex);
    }
    else if (currentIndex > prevSum + currentLength)
    {
        return Recursive(prevSum, currentLength - 1, currentIndex - prevSum - currentLength);
    }
    else
    {
        return currentIndex - prevSum - 1 == 0 ? 'm' : 'o';
    }
}

var answer = Recursive(sum, length, N);
sw.WriteLine(answer);

sr.Close();
sw.Close();