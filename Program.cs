using CSharpLearning.Class01;
using CSharpLearning.Class02;

namespace CSharpLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            // 想运行哪节课,就调用哪节课的 Run()。改这一行即可。
            // Lesson02.Run();
            Lesson11.Run();
            // Lesson12.Run();
            // Lesson13.Run();
            // Lesson14.Run();
            // Lesson15.Run();
            // Lesson16 在 Class01/Class02 都有,同名类要写全名区分
            CSharpLearning.Class02.Lesson16.Run();
            
            
            CSharpLearning.Class01.Lesson01.Run();
            CSharpLearning.Class02.Lesson01.Run();
            CSharpLearning.Class02.Lesson07b.Run();
            CSharpLearning.Class02.Lesson13.Run();
        }
    }
}
