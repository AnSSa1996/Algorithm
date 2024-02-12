var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var T = int.Parse(sr.ReadLine());                   // 테스트 케이스의 개수
for (var i = 0; i < T; i++)
{
    var N = int.Parse(sr.ReadLine());               // 카드의 갯수
    var cards = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    var dp = new int[1001, 1001];

    var turn = true;
    var left = 0;
    var right = N - 1;
    GetMax(left, right, turn);
    
    int GetMax(int left, int right, bool turn)
    {
        if (left > right) return 0;
        if (dp[left, right] != 0) return dp[left, right];

        if (turn)
        {
            dp[left, right] = Math.Max(GetMax(left + 1, right, !turn) + cards[left], GetMax(left, right - 1, !turn) + cards[right]);
        }
        else
        {
            dp[left, right] = Math.Min(GetMax(left + 1, right, !turn), GetMax(left, right - 1, !turn));
        }

        return dp[left, right];
    }
    
    sw.WriteLine(dp[left, right]);
}

sw.Close();
sr.Close();
