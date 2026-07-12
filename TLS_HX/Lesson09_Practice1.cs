namespace TLS_HX.Lesson09_Practice1;

public class Lesson09_Practice1
{
    public static void Run()
    {
        int value = 10;
        int result = value.Square();
        Console.WriteLine(result);
    }
}

static class Tools
{
    public static int Square(this int source)
    {
        return source * source;
    }
}