using System;
using System.IO;
using System.Linq;

namespace Backj
{
    internal class Program
    {
        static int[][] data;
        static int[] directions;
        static int[][][] priorities;
        static int[,,] smell;
        static int n, m, k;

        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        public static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sw = new StreamWriter(Console.OpenStandardOutput());

            // 입력 받기
            var input = sr.ReadLine().Split().Select(int.Parse).ToArray();
            n = input[0];
            m = input[1];
            k = input[2];

            data = new int[n][];
            for (int i = 0; i < n; i++)
            {
                data[i] = sr.ReadLine().Split().Select(int.Parse).ToArray();
            }

            directions = sr.ReadLine().Split().Select(int.Parse).ToArray();
            priorities = new int[m][][];

            for (int i = 0; i < m; i++)
            {
                priorities[i] = new int[4][];
                for (int j = 0; j < 4; j++)
                {
                    priorities[i][j] = sr.ReadLine().Split().Select(int.Parse).ToArray();
                }
            }

            smell = new int[n, n, 2];

            // 시뮬레이션 시작
            var answer = 0;
            while (true)
            {
                UpdateSmell();
                data = Move();
                answer++;

                if (IsOneSharkLeft() || answer > 1000)
                {
                    sw.WriteLine(answer > 1000 ? -1 : answer);
                    break;
                }
            }

            sw.Close();
            sr.Close();
        }

        static void UpdateSmell()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (smell[i, j, 1] > 0)
                    {
                        smell[i, j, 1]--;
                    }

                    if (data[i][j] != 0)
                    {
                        smell[i, j, 0] = data[i][j];
                        smell[i, j, 1] = k;
                    }
                }
            }
        }

        static int[][] Move()
        {
            var new_data = new int[n][];
            for (int i = 0; i < n; i++)
            {
                new_data[i] = new int[n];
            }

            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if (data[x][y] != 0)
                    {
                        int sharkNumber = data[x][y];
                        int direction = directions[sharkNumber - 1];
                        bool found = false;

                        for (int idx = 0; idx < 4; idx++)
                        {
                            int dirIndex = priorities[sharkNumber - 1][direction - 1][idx] - 1;
                            int nx = x + dx[dirIndex];
                            int ny = y + dy[dirIndex];

                            if (nx >= 0 && nx < n && ny >= 0 && ny < n)
                            {
                                if (smell[nx, ny, 1] == 0)
                                {
                                    directions[sharkNumber - 1] = dirIndex + 1;
                                    new_data[nx][ny] = new_data[nx][ny] == 0 ? sharkNumber : Math.Min(sharkNumber, new_data[nx][ny]);
                                    found = true;
                                    break;
                                }
                            }
                        }

                        if (!found)
                        {
                            for (int idx = 0; idx < 4; idx++)
                            {
                                int dirIndex = priorities[sharkNumber - 1][direction - 1][idx] - 1;
                                int nx = x + dx[dirIndex];
                                int ny = y + dy[dirIndex];

                                if (nx >= 0 && nx < n && ny >= 0 && ny < n && smell[nx, ny, 0] == sharkNumber)
                                {
                                    directions[sharkNumber - 1] = dirIndex + 1;
                                    new_data[nx][ny] = sharkNumber;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return new_data;
        }

        static bool IsOneSharkLeft()
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (data[i][j] > 1)
                        return false;
                    if (data[i][j] == 1)
                        count++;
                }
            }

            return count == 1;
        }
    }
}