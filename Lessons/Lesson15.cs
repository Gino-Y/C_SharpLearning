namespace CSharpLearning.Lessons;

public class Lesson15
{
    public static void Run()
    {
        // 数组
        int[] intArray = new int[3];
        intArray[2] = 10;
        Console.WriteLine(intArray[0]); // 输出 0
        Console.WriteLine(intArray[1]); // 输出 0   
        Console.WriteLine(intArray[2]); // 输出 10    
        intArray[2] = 20;
        Console.WriteLine(intArray[2]);
        Console.WriteLine("-----------------A");
        intArray[0] = 20;
        intArray[1] = 10;
        intArray[2] = 5;
        
        for (int i = 0; i < intArray.Length; i++)
        {
            Console.WriteLine(intArray[i]);
        }
        
        Console.WriteLine("-----------------B");
        // 迭代
        foreach (var item in intArray)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("-----------------C");
        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = i * 10;
        }
        for (int i = 0; i < intArray.Length; i++)
        {
            Console.WriteLine(intArray[i]);
        }

        Console.WriteLine("-----------------D");
        // 数组初始化的几种方法
        int[] intArray2 = new int[] { 1, 2, 3, 4, 5 };
        int[] intArray3 = new int[5] { 1, 2, 3, 4, 5 };
        int[] intArray4 = { 1, 2, 3, 4, 5 };
    }
}