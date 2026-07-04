namespace CSharpLearning.Lessons;

public class Lesson12
{
    public static void Run()
    {
        // 分支语句
        int a = 9;

        switch (a)
        {
            case 0:
                Console.WriteLine("a == 0");
                break;
            case 1:
                Console.WriteLine("a == 1");
                break;
            case 2:
                Console.WriteLine("a == 2");
                break;
            default:
                Console.WriteLine("a == ?");
                break;
        }
    }
}
