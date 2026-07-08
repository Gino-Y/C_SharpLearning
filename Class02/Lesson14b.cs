namespace CSharpLearning.Class02;

public class Lesson14b
{
    public static void Run()
    {
        // Queue<T> 队列：先进先出（像排队，先来的先走）
        // 术语：Enqueue = 入队，Dequeue = 出队
        // 优点：入队/出队只动队尾/队首，速度快
        // 缺点：只能动两端，不能按下标访问中间元素
        // 用途：任务排队、消息队列、打印队列
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(1);   // 入队（排到队尾）
        queue.Enqueue(2);
        queue.Enqueue(3);   // 队首是 1，队尾是 3

        Console.WriteLine(queue.Peek());      // 1，只看队首，不取出
        Console.WriteLine(queue.Dequeue());   // 1，出队：取出队首
        Console.WriteLine(queue.Dequeue());   // 2
        Console.WriteLine(queue.Count);       // 1，剩 1 个
    }
}
