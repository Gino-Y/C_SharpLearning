namespace CSharpLearning.Class02;

public class Lesson07
{
    public static void Run()
    {
        // ZangAo zang = new ZangAo();
        // zang.name = "zang";
        // zang.Eat();
        // zang.Color = "black";
        // Console.WriteLine($"{zang.name} color: {zang.Color}");

        Animal mimi = new Cat();
        mimi.name = "Mimi";
        mimi.Eat();
        mimi.Sleep();
        mimi.Walk();

        Camel tuotuo = new Camel();
        tuotuo.name = "huotuo";
        tuotuo.Sleep();
        tuotuo.Walk();
    }
}

public class Cat : Animal
{
    public override void Walk()
    {
        Console.WriteLine($"{name} is walking~~~.");  
    }

    public override void Sleep()
    {
        Console.WriteLine("huhuhu~");
    }
}

public class Camel : Animal
{
    public override void Walk()
    {
        Console.WriteLine($"{name} is walking walking.");  
    }

    public override void Sleep()
    {
        Console.WriteLine("hahaha~");
    }
}

public abstract class Animal
{
    public string name;
    public int age;
    
    public void Eat()
    {
        Console.WriteLine($"{name} is eating.");
    }

    // 抽象方法 父类中不能实现 子类中必须实现
    public abstract void Sleep();

    public virtual void Walk()
    {
        Console.WriteLine($"{name} is walking.");   
    }
}