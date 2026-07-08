namespace CSharpLearning.Class02;
using System.Collections.Generic;

public class Lesson13
{
    public static void Run()
    {
        List<int> lst = new List<int>(); // 列表（动态数组），不指定范围不报错
        // int[] l = new int[]; // 数组，不指定范围会报错
        
        List<int> lst2 = new List<int>(2);
        lst2.Add(2);
        lst2.Add(3);
        lst2.Add(5);
        lst2.Insert(1, 10);
        lst2.Clear();

        for (int i = 0; i < lst2.Count; i++)
        {
            Console.WriteLine(lst2[i]);
        }
    }
}