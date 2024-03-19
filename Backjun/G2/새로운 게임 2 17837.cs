using System;
using System.Collections.Generic;

var inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
var n = inputs[0];
var k = inputs[1];

var board = new int[n, n];
for (int i = 0; i < n; i++)
{
    var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++)
    {
        board[i, j] = input[j];
    }
}

var horsePositions = new int[k][];
for (var i = 0; i < k; i++)
{
    horsePositions[i] = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
}

HorseGame game = new HorseGame(n, k, board, horsePositions);
game.StartGame();


public class HorseGame
{
    int n, k;
    int[,] board;
    List<int>[,] chess;
    int[] dx = new int[] {0, 0, -1, 1};
    int[] dy = new int[] {1, -1, 0, 0};
    List<int[]> horse;
    int count = 1;

    public HorseGame(int n, int k, int[,] board, int[][] horsePositions)
    {
        this.n = n;
        this.k = k;
        this.board = board;
        this.chess = new List<int>[n, n];
        this.horse = new List<int[]>();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                chess[i, j] = new List<int>();
            }
        }

        for (int i = 0; i < k; i++)
        {
            int[] pos = horsePositions[i];
            horse.Add(new int[] { pos[0] - 1, pos[1] - 1, pos[2] - 1 });
            chess[pos[0] - 1, pos[1] - 1].Add(i);
        }
    }

    private int ChangeDir(int d)
    {
        if (d == 0 || d == 2) d += 1;
        else if (d == 1 || d == 3) d -= 1;
        return d;
    }

    private bool Solve(int hNum)
    {
        int[] h = horse[hNum];
        int x = h[0], y = h[1], d = h[2];
        int nx = x + dx[d], ny = y + dy[d];

        if (nx < 0 || nx >= n || ny < 0 || ny >= n || board[nx, ny] == 2)
        {
            d = ChangeDir(d);
            horse[hNum][2] = d;
            nx = x + dx[d];
            ny = y + dy[d];
            if (nx < 0 || nx >= n || ny < 0 || ny >= n || board[nx, ny] == 2) return true;
        }

        List<int> horseUp = new List<int>();
        for (int i = 0; i < chess[x, y].Count; i++)
        {
            if (chess[x, y][i] == hNum)
            {
                horseUp.AddRange(chess[x, y].GetRange(i, chess[x, y].Count - i));
                chess[x, y].RemoveRange(i, chess[x, y].Count - i);
                break;
            }
        }

        if (board[nx, ny] == 1) horseUp.Reverse();

        foreach (var hIdx in horseUp)
        {
            horse[hIdx][0] = nx;
            horse[hIdx][1] = ny;
            chess[nx, ny].Add(hIdx);
        }

        if (chess[nx, ny].Count >= 4) return false;
        return true;
    }

    public void StartGame()
    {
        while (true)
        {
            bool what = false;
            if (count > 1000)
            {
                Console.WriteLine(-1);
                break;
            }

            for (int i = 0; i < k; i++)
            {
                if (!Solve(i))
                {
                    what = true;
                    break;
                }
            }

            if (what)
            {
                Console.WriteLine(count);
                break;
            }
            count++;
        }
    }
}