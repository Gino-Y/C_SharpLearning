namespace CSharpLearning.Lessons;

public class Lesson14
{
    public static void Run()
    {
        // for 循环
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"i = {i}");
        }

        // foreach 循环
        string[] names = { "Alice", "Bob", "Charlie" };
        foreach (string name in names)
        {
            Console.WriteLine($"name = {name}");
        }
    }
}