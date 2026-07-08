namespace CSharpLearning.Class02;

public class Lesson18
{
    public static void Run()
    {
        // enum 枚举：一组有名字的常量（值类型），代替魔法数字/字符串
        Season now = Season.Summer;
        Console.WriteLine(now);          // Summer，打印的是名字
        Console.WriteLine((int)now);     // 1，底层其实是整数（默认从 0 开始）

        // 整数 ↔ 枚举 互转
        Season s = (Season)2;            // 2 → Autumn
        Console.WriteLine(s);

        // 常和 switch 搭配：取值固定，分支清晰
        switch (now)
        {
            case Season.Spring:
                Console.WriteLine("春暖花开");
                break;
            case Season.Summer:
                Console.WriteLine("烈日炎炎");
                break;
            default:
                Console.WriteLine("秋冬");
                break;
        }
    }
}

// 枚举：值类型，成员默认对应 0,1,2,3...（也可手动指定，如 Spring = 1）
enum Season
{
    Spring,   // 0
    Summer,   // 1
    Autumn,   // 2
    Winter    // 3
}
