var sw = new StreamWriter(Console.OpenStandardOutput());
var sr = new StreamReader(Console.OpenStandardInput());

var inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
var (x1, y1, x2, y2) = (inputs[0], inputs[1], inputs[2], inputs[3]);
inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
var (x3, y3, x4, y4) = (inputs[0], inputs[1], inputs[2], inputs[3]);

var ccw1 = CCW(x1, y1, x2, y2, x3, y3);                           // 선분 (x1, y1), (x2, y2) 와 점 (x3, y3) 의 위치 관계
var ccw2 = CCW(x1, y1, x2, y2, x4, y4);                      // 선분 (x1, y1), (x2, y2) 와 점 (x4, y4) 의 위치 관계
var ccw3 = CCW(x3, y3, x4, y4, x1, y1);           // 선분 (x3, y3), (x4, y4) 와 점 (x1, y1) 의 위치 관계
var ccw4 = CCW(x3, y3, x4, y4, x2, y2);           // 선분 (x3, y3), (x4, y4) 와 점 (x2, y2) 의 위치 관계

var result = 0;
if (ccw1 * ccw2 <= 0 && ccw3 * ccw4 <= 0)   // 교차 할 때
{
    if (ccw1 == 0 && ccw2 == 0 && ccw3 == 0 && ccw4 == 0) // 선분이 일직선 상에 있을 때
    {
        if (x1 > x2) (x1, x2) = (x2, x1);
        if (x3 > x4) (x3, x4) = (x4, x3);
        if (y1 > y2) (y1, y2) = (y2, y1);
        if (y3 > y4) (y3, y4) = (y4, y3);

        if (x2 >= x3 && x4 >= x1 && y2 >= y3 && y4 >= y1) result = 1;
    }
    else result = 1;
}

sw.WriteLine(result);

long CCW(long x1, long y1, long x2, long y2, long x3, long y3)
{
    // 선분 (x1, y1), (x2, y2) 와 점 (x3, y3) 의 위치 관계
    var value = (x2 - x1) * (y3 - y1) - (y2 - y1) * (x3 - x1);
    if (value > 0) return 1;        // 반시계 방향
    if (value < 0) return -1;       // 시계 방향
    return 0;
}

sw.Close();
sr.Close();