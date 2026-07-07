namespace CSharpLearning.Class02;

public class Lesson07b
{
    public static void Run()
    {
        // 里氏转换原则
        static void BeginCar(CarA car)
        {
            car.Begin();
        }

        Audi audi = new Audi();
        Auto auto = new Auto();
        BeginCar(audi);
        BeginCar(auto);
    }
}

class Audi : CarA
{
    public override void Begin()
    {
        Console.WriteLine("按钮启动");
    }

    public override void ChangeGear()
    {
        Console.WriteLine("自动换挡");
    }
}

class Auto : CarA
{
    public override void Begin()
    {
        Console.WriteLine("钥匙启动");
    }

    public override void ChangeGear()
    {
        Console.WriteLine("手动换挡");
    }
}

class CarA : Car
{
    public virtual void Begin()
    {
        Console.WriteLine("启动");
    }
    public virtual void ChangeGear()
    {
        Console.WriteLine("通用换挡");
    }
}