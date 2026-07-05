namespace CSharpLearning.Lessons;

public class Lesson17
{
    public static void Run()
    {
        // 方法（函数）
        // 方法的重载必须满足以下条件之一：
        // 1. 参数个数不同
        // 2. 参数类型不同
        // 封装
        
        Speak();
        Console.WriteLine("End!");
        Console.WriteLine("-----------------Add");
        int result1 = Add(1, 2);
        float result2 = Add(1.5f, 2.5f);
        Console.WriteLine($"Int result: {result1}");
        Console.WriteLine($"Float result: {result2}");
    }
    
    static void Speak()
    {
        Console.WriteLine("Hello World!");
    }
    
    // 方法的参数 形参（可以有默认值） 实参
    static int Add(int a, int b)
    {
        return a + b;
    }
    // 方法重载
    static float Add(float a, float b=2)
    {
        return a + b;
    }

}