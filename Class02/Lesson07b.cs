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
        
        audi.HotChair();
    }
}

class Audi : CarA, IHotChair
{
    public override void Begin()
    {
        Console.WriteLine($"{nameof(Audi)}按钮启动");
    }

    public override void ChangeGear()
    {
        Console.WriteLine($"{nameof(Audi)}自动换挡");
    }

    public void HotChair()
    {
        Console.WriteLine($"{nameof(Audi)}有座椅加热");
    }
}

class Auto : CarA
{
    public override void Begin()
    {
        Console.WriteLine($"{nameof(Auto)}钥匙启动");
    }

    public override void ChangeGear()
    {
        Console.WriteLine($"{nameof(Auto)}手动换挡");
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