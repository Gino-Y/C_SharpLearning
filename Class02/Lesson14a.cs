namespace CSharpLearning.Class02;

public class Lesson14a
{
    public static void Run()
    {
        // Stack<T> 栈：后进先出（最后放的最先拿）
        // 术语：Push = 入栈/压栈（同义），Pop = 出栈/弹栈（同义）
        // 优点：Push/Pop 都在栈顶操作，速度快
        // 缺点：只能动栈顶，不能按下标访问中间元素
        // 用途：撤销(Ctrl+Z)、方法调用栈、括号匹配
        Stack<int> stack = new Stack<int>();

        stack.Push(1);   // 入栈（压栈）
        stack.Push(2);
        stack.Push(3);   // 栈顶是 3

        foreach (int item in stack)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("-----------------");
        Console.WriteLine(stack.Peek());   // 3，只看栈顶，不取出
        Console.WriteLine(stack.Pop());    // 3，出栈（弹栈）：取出栈顶
        Console.WriteLine(stack.Pop());    // 2
        Console.WriteLine(stack.Count);    // 1，剩 1 个
    }
}
