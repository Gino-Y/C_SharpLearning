using System;

namespace CSharpLearning.Lessons
{
    class Lesson11
    {
        public static void Run()
        {
            // 逻辑语句
            int a = 6;
            // if (a > 10)
            // {
            //     Console.WriteLine("a is greater than 10");
            // }
            // else if (a < 5)
            // {
            //     Console.WriteLine("a is less than 5");
            // }
            // else
            // {
            //     Console.WriteLine("a is between 5 and 10");
            // }
            
            if (a < 10 && a > 5)
            {
                Console.WriteLine("a is between 5 and 10");
            }
            else
            {
                Console.WriteLine("a is not between 5 and 10");
            }
            Console.WriteLine($"a = {a}");
        }
    }
}
