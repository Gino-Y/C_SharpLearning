namespace CSharpLearning.Class02;

public class Lesson19b
{
    public static void Run()
    {
        // 委托版本实现（ClassRoom 复用 Lesson19a 的）
        ClassControllerB controller = new ClassControllerB();

        // 控制器不持有教室列表，教室把自己的方法「注册」进委托
        for (int i = 101; i <= 111; i++)
        {
            ClassRoom room = new ClassRoom(i.ToString());
            controller.OnClassOver += room.ClassOver;   // += 注册（多播委托）
        }

        controller.ClassOver();   // 广播：注册进来的方法全部执行
    }
}

class ClassControllerB
{
    // 1. 声明委托类型：规定能装「无参、无返回值」的方法
    public delegate void ClassOverHandler();

    // 2. 委托变量：装着所有「下课时要执行的方法」
    public ClassOverHandler? OnClassOver;

    // 3. 调用委托 = 挨个执行装进来的方法
    public void ClassOver()
    {
        OnClassOver?.Invoke();   // ?. 判空：没人注册时不报错
    }

    // 对比 Lesson19a：这里没有 List<ClassRoom> 字段！
    // 控制器不认识教室，谁想被通知谁自己 +=，食堂宿舍也能注册，此类无需改动
}
