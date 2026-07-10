namespace TLS_HX;

public class Lesson08_Practice1
{
    public static void Run()
    {
        Console.WriteLine(MathTool.CalcCircuarAres(10));
        Console.WriteLine(MathTool.CalcRectangleLength(10));
        Console.WriteLine(MathTool.CalcRectArea(10, 20));
        Console.WriteLine(MathTool.CalcRectLength(10, 20));
        Console.WriteLine(MathTool.GetABS(10));
        Console.WriteLine(MathTool.GetABS(-10));
        Console.WriteLine(MathTool.GetABS(0));
        Console.WriteLine(MathTool.GetABS(-0));
    }
}

static class MathTool
{
    /// <summary>
    /// 计算圆的面积
    /// </summary>
    /// <param name="radius">半径</param>
    /// <returns>面积</returns>
    public static float CalcCircuarAres(float radius)
    {
        return (float)(Math.PI * radius * radius);
    }

    /// <summary>
    /// 计算矩形的周长
    /// </summary>
    /// <param name="width">宽度</param>
    /// <param name="height">高度</param>
    /// <returns>周长</returns>
    public static float CalcRectangleLength(float radius)
    {
        return 2 * (float)Math.PI * radius;
    }

    public static float CalcRectArea(float width, float height)
    {
        return width * height;
    }

    public static float CalcRectLength(float width, float height)
    {
        return 2 * (width + height);
    }

    public static float GetABS(float number)
    {
        return number >= 0 ? number : -number;
    }
}



