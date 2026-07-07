namespace CSharpLearning.Class02;

public class Lesson07
{
    public static void Run()
    {
        ZangAo zang = new ZangAo();
        zang.Eat();
        zang.Color = "black";
        Console.WriteLine($"zang color: {zang.Color}");
    }
}

public class Animal
{
    public string name;
    public int age;
    
    public void Eat()
    {
        Console.WriteLine($"{name} is eating.");
    }

    public void Sleep()
    {
        Console.WriteLine($"{name} is sleeping.");
    }

    public void Walk()
    {
        Console.WriteLine($"{name} is walking.");   
    }
}