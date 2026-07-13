namespace TLS_HX.Lesson06_Practice1;

// 索引器：让对象像数组一样用中括号访问。概念、语法、要点见笔记《索引器》
public class Lesson06_Practice1
{
    public static void Run()
    {
        IntArray array = new IntArray();
        array.Add(100);
        array.Add(100);
        array.Add(200);
        Console.WriteLine($"开始有{array.Count}个元素");
        array.RemoveAt(1);
        Console.WriteLine($"删除后有{array.Count}个元素");
        array.Remove(200);
        Console.WriteLine($"删除后有{array.Count}个元素");
        Console.WriteLine(array[0]);
        Console.WriteLine(array[1]);
        Console.WriteLine(array[2]);
        Console.WriteLine(array[3]);
    }
}

#region 习题
/*
自定义一个整形数组类
该类中有一个整形数组变量
为它封装增删改查的方法
*/
#endregion

class IntArray
{
    private int[] array;
    //房间容量
    private int capacity;
    //元素个数
    private int count;

    public IntArray()
    {
        capacity = 5;
        count = 0;
        array = new int[capacity];
    }

    //曾
    public void Add(int value)
    {
        //如果要增加就涉及扩容
        //扩容就涉及“搬家”
        //搬家就涉及性能
        //所以我们要尽量减少搬家次数
        if (count < capacity)
        {
            array[count] = value;
            count++;
        }
        //否则扩容
        else
        {
            capacity *= 2;
            //新房间
            int[] tampArray = new int[capacity];
            //搬家
            for(int i = 0; i < count; i++)
            {
                tampArray[i] = array[i];
            }
            //搬家完成
            array = tampArray;
            //往后面放
            array[count] = value;
            count++;
        }
    }
    //删
    public void Remove(int value)
    {
        for (int i = 0; i < count; i++)
        {
            if (array[i] == value)
            {
                RemoveAt(i);
                return;
            }
        }
        Console.WriteLine($"没有找到{value}，无法删除");
    }

    public void RemoveAt(int index)
    {
        if (index > count - 1)
        {
            Console.WriteLine($"当前数组只有{count}个元素，你越界了");
        }

        for (int i = index; i < count - 1; i++)
        {
            array[i] = array[i + 1];
        }
        count--;
    }

    //查改
    public int this[int index]
    {
        get
        {
            if (index >= count || index < 0)
            {
                Console.WriteLine($"当前数组只有{count}个元素，你越界了");
                return 0;
            }
            return array[index];
        }
        set
        {
            if (index >= count || index < 0)
            {
                Console.WriteLine($"当前数组只有{count}个元素，你越界了");
            }
            array[index] = value;
        }
    }

    public int Count
    {
        get
        {
            return count;
        }
    }
}