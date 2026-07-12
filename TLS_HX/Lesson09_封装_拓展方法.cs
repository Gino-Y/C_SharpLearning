namespace TLS_HX.Lesson09;

public class Lesson09
{
    public static void Run()
    {
        int value = 10;
        value.SpeakValue();

        string str = "Hello, World!";
        str.SpeakStringInfo("Hello", "World");

        Test test = new Test();
        test.Func1();
        test.Func2();
        Tools.Func2(test);
    }
}

/// <summary>
/// 工具类
/// </summary>
static class Tools
{
    /// <summary>
    /// 拓展方法：给int类型添加一个SpeakValue方法
    /// 成员方法需要实例化对象，而拓展方法不需要
    /// value就是int类型的实例
    /// </summary>
    /// <param name="value">值</param>
    /// <returns>值</returns>
    public static void SpeakValue(this int value)
    {
        // 拓展方法的逻辑
        Console.WriteLine($"The value is {value}");
    }

    /// <summary>
    /// 拓展方法：给string类型添加一个SpeakStringInfo方法
    /// </summary>
    /// <param name="source">调用方法的对象</param>
    /// <param name="str2">传的参数1</param>
    /// <param name="str3">传的参数2</param>
    public static void SpeakStringInfo(this string source, string str2, string str3)
    {
        Console.WriteLine($"唐老师为string拓展的方法");
        Console.WriteLine($"调用方法的对象： {source}");
        Console.WriteLine($"传的参数： {str2}");
        Console.WriteLine($"传的参数： {str3}");
    }

    /// <summary>
    /// 拓展方法：为自定义的类拓展方法
    /// 与成员方法重名时成员方法优先；<br>改用 Tools.Func2(test) 仍可调到
    /// </summary>
    /// <param name="source">调用方法的对象</param>
    public static void Func2(this Test source)
    {
        Console.WriteLine($"789");
    }
}

/// 自定义的类
/// </summary>
public class Test
{
    public int i = 10;

    public void Func1()
    {
        Console.WriteLine($"123");
    }

    public void Func2()
    {
        Console.WriteLine($"456");
    }
}
