namespace CSharpLearning.Class02;

public class Lesson12
{
    public static void Run()
    {
        // 泛型
        // T 通用类型
        ShowTool.ShowSomething(1);
        ShowTool.ShowSomething("Hello, World!");
        ShowTool.ShowSomething(3.1415926535);
        ShowTool.ShowCarLogo(new Car("BMW"));
        // 泛型类：List<int>
    }
}

class ShowTool
{
    // public static void ShowSomething(int show)
    // {
    //     Console.WriteLine($"ShowSomething: {show}");
    // }
    // public static void ShowSomething(string show)
    // {
    //     Console.WriteLine($"ShowSomething: {show}");
    // }
    
    public static void ShowSomething<T>(T show)
    {
        Console.WriteLine($"ShowSomething: {show}");
    }

    // 泛型方法
    public static void ShowCarLogo<T>(T car) where T : Car
    {
        Console.WriteLine($"Show Car Logo: {car.logo}");
    }
    // 泛型约束的条件
    // 可多约束
    // 结构体
    // 类
    // new()无参构造函数的对象
    // 基类
    // 接口
}