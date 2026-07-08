namespace CSharpLearning.Class02;

public class Lesson06
{
    public static void Run()
    {
        int a = 10;
        int b = 20;
        Exchange(a, b);
        Console.WriteLine($"a: {a}, b: {b}");
        
        ZangAo SangJi = new ZangAo { Age = 5 };
        ZangAo ZhuoMa = new ZangAo { Age = 10 };
        Exchange(SangJi, ZhuoMa);
        Console.WriteLine($"SangJi Age: {SangJi.Age}, ZhuoMa Age: {ZhuoMa.Age}");
    }
    static void Exchange(int a, int b)// 参数列表会新建值类型
    {
        int temp = a;
        a = b;
        b = temp;
    }    
    static void Exchange(ZangAo a, ZangAo b)
    {
        int temp = a.Age;
        a.Age = b.Age;
        b.Age = temp;
    }
}

class ZangAo : Dog
{
    public string Color { get; set; }
}