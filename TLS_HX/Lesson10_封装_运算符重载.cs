namespace TLS_HX.Lesson10;

public class Lesson10
{
    public static void Run()
    {
        Point p1 = new Point();
        p1.x = 1;
        p1.y = 2;
        Point p2 = new Point();
        p2.x = 3;
        p2.y = 4;
        Point p3 = p1 + p2;
        Console.WriteLine($"p3.x: {p3.x}, p3.y: {p3.y}");
    }
}

#region 运算符重载
class Point
{
    public int x;
    public int y;

    public static Point operator +(Point p1, Point p2)
    {
        Point p = new Point();
        p.x = p1.x + p2.x;
        p.y = p1.y + p2.y;
        return p;
    }

    public static Point operator +(Point p, int value)
    {
        Point result = new Point();
        result.x = p.x + value;      // 读参数 p，写结果 result
        result.y = p.y + value;
        return result;
    }

    public static Point operator +(int value, Point p)
    {
        return p + value;            // 复用上面的 (Point, int) 重载
    }
}
#endregion