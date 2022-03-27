using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string[,] places) {
        int[] answer = new int[5];
            for (int i = 0; i < 5; i++)
            {

                Queue<Ppos> q = new Queue<Ppos>();
                int result = 1;

                for (int Y = 0; Y < 5; Y++)
                {
                    for (int X = 0; X < 5; X++)
                    {
                        if (places[i, Y][X] == 'P')
                        {
                            q.Enqueue(new Ppos(Y, X));
                        }
                    }
                }

                while (q.Count > 0)
                {
                    Ppos p = q.Dequeue();
                    int currentY = p.Y;
                    int currentX = p.X;

                    if (currentX + 1 < 5)
                    {
                        char c = places[i, currentY][currentX + 1];
                        if (c == 'P')
                        {
                            result = 0;
                            break;
                        }
                        else if (c == 'O')
                        {
                            if (currentX + 2 < 5)
                            {
                                c = places[i, currentY][currentX + 2];
                                if (c == 'P')
                                {
                                    result = 0;
                                    break;
                                }
                            }
                        }
                    }
                    if (currentY + 1 < 5)
                    {
                        char c = places[i, currentY + 1][currentX];
                        if (c == 'P')
                        {
                            result = 0;
                            break;
                        }
                        else if (c == 'O')
                        {
                            if (currentY + 2 < 5)
                            {
                                c = places[i, currentY + 2][currentX];
                                if (c == 'P')
                                {
                                    result = 0;
                                    break;
                                }
                            }
                        }
                    }
                    if (currentX - 1 >= 0 && currentY + 1 < 5)
                    {
                        char c = places[i, currentY + 1][currentX - 1];

                        if (c == 'P')
                        {
                            if(!((places[i,currentY][currentX - 1] == 'X') && (places[i, currentY + 1][currentX] == 'X')))
                            {
                                result = 0;
                                break;
                            }
                        }
                    }

                    if (currentX + 1 < 5 && currentY + 1 < 5)
                    {
                        char c = places[i, currentY + 1][currentX + 1];

                        if (c == 'P')
                        {
                            if (!((places[i, currentY][currentX + 1] == 'X') && (places[i, currentY + 1][currentX] == 'X')))
                            {
                                result = 0;
                                break;
                            }
                        }
                    }
                }

                answer[i] = result;
            }
        return answer;
    }
}

public class Ppos
        {
            public int Y;
            public int X;
            public Ppos(int y, int x)
            {
                Y = y; X = x;
            }
        }