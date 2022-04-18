using System;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int W = inputs[0];
            int H = inputs[1];

            int[] pos = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int X = pos[0];
            int Y = pos[1];



            int T = int.Parse(Console.ReadLine());


            int dx = X + T;
            int dy = Y + T;

            dx %= 2 * W; dy %= 2 * H;

            if (dx > W) dx = 2 * W - dx;
            if (dy > H) dy = 2 * H - dy;

            Console.WriteLine($"{dx} {dy}");
        }
    }
}
