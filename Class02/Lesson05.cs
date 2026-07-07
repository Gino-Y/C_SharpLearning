namespace CSharpLearning.Class02;

public class Lesson05
{
    public static void Run()
    {
        // 静态不用new实例化
        // 整个程序的生命周期
        
        Dog dog1 = new Dog();
        dog1.Age = 3;
        Dog.num++;
        Console.WriteLine($"Dog1 Age: {dog1.Age}, Dog.num: {Dog.num}");

        Dog dog2 = new Dog();
        dog2.Age = 5;
        Dog.num++;
        Console.WriteLine($"Dog2 Age: {dog2.Age}, Dog.num: {Dog.num}");
        
        // 静态方法在工具中用
        int c = NumTool.Add(3, 5);
    }
}

public class Dog : Animal
{
    public int Age { get; set; }
    public static int num { get; set; }
}

class NumTool
{
    public static int Add(int num1, int num2)
    {
        return num1 + num2;
    }
    public static float Add(float num1, float num2)
    {
        return num1 + num2;
    }
}
