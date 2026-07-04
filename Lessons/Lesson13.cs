namespace CSharpLearning.Lessons;

public class Lesson13
{
    public static void Run()
    {
        int num = 6;
        // while (num < 5 )
        // {
        //     Console.WriteLine($"num = {num}");
        //     num++;
        // }
        //
        // Console.WriteLine("Hello World!");
        // //------------

        do
        {
            Console.WriteLine($"num = {num}");
            num++;
        } while (num < 5);

        Console.WriteLine("Hello World!");
        //-----------
    }
}