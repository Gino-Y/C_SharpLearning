namespace CSharpLearning.Class02;

public class Lesson15
{
    public static void Run()
    {
        // LinkedList<T> 链表：节点用「前后指针」串起来，没有下标
        // 优点：头尾/中间插入删除快；缺点：不能用 lst[i] 随机访问
        //
        // 单向链表：节点只有 Next，只能从头往尾走
        // 双向链表：节点有 Prev + Next，可双向遍历
        // C# 的 LinkedList<T> 是双向链表，节点是 LinkedListNode<T>（有 Previous/Next）
        LinkedList<int> list = new LinkedList<int>();

        list.AddLast(1);    // 加到尾部
        list.AddLast(2);    // 1 -> 2
        list.AddFirst(0);   // 加到头部：0 -> 1 -> 2

        Console.WriteLine(list.First.Value);   // 0，头节点
        Console.WriteLine(list.Last.Value);    // 2，尾节点
        Console.WriteLine(list.Count);         // 3

        // 双向的体现：从尾节点往回走
        Console.WriteLine(list.Last.Previous.Value);   // 1，尾节点的前一个

        // 中间插入/删除：先 Find 找到节点，再在它前后操作
        LinkedListNode<int> node = list.Find(1);   // 找到值为 1 的节点
        list.AddAfter(node, 9);    // 在它后面插：0 -> 1 -> 9 -> 2
        list.AddBefore(node, 7);   // 在它前面插：0 -> 7 -> 1 -> 9 -> 2
        list.Remove(node);         // 删除该节点：0 -> 7 -> 9 -> 2
        list.Remove(9);            // 也可以按值删（删第一个匹配的）：0 -> 7 -> 2

        list.RemoveFirst();   // 删头：7 -> 2
        list.RemoveLast();    // 删尾：7

        foreach (int item in list)   // 从头到尾遍历
        {
            Console.WriteLine(item);   // 7
        }
    }
}
