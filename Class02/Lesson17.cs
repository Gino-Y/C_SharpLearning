namespace CSharpLearning.Class02;

public class Lesson17
{
    public static void Run()
    {
        // struct 结构体：自定义的「值类型」（class 是引用类型）
        Point p1 = new Point(3, 4);
        Console.WriteLine($"p1: ({p1.X}, {p1.Y})");   // (3, 4)

        // 值类型的体现：赋值 = 复制一份，两者独立
        Point p2 = p1;    // 把 p1 的值复制给 p2
        p2.X = 100;
        Console.WriteLine($"p1.X = {p1.X}");   // 3，p1 不受影响
        Console.WriteLine($"p2.X = {p2.X}");   // 100

        // 对比：如果 Point 是 class（引用类型），p2 = p1 后两者指向同一对象，
        // 改 p2.X 会连带 p1.X 一起变（见 Lesson06 值类型与引用类型）

        // struct vs class：
        //   struct 值类型（赋值复制、不能继承但可以实现接口、不能为 null），适合小而简单的数据
        //   class  引用类型（赋值传地址、支持继承多态），复杂对象默认用它
        //   int/double/bool/DateTime 其实都是微软写好的 struct

        // struct vs List：不是一类东西，不用比
        //   struct 定义「一个东西长什么样」（元素的模板）
        //   List   是「装一堆东西的容器」，两者配合使用：
        List<Point> points = new List<Point>();
        points.Add(new Point(1, 2));
        points.Add(p1);
        Console.WriteLine(points.Count);   // 2
    }
}

// 结构体：和 class 写法几乎一样，把关键字换成 struct
struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y)   // 结构体也可以有构造函数、方法
    {
        X = x;
        Y = y;
    }
}
