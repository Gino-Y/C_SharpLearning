namespace CSharpLearning.Class02;

public class Lesson04
{
    public static void Run()
    {
        Car car = new Car("Toyota");
        // car.Init("Toyota");
        Console.WriteLine(car.logo);
    }
}

// class Car
// {
//     public string logo;
//
//     public void Init(string lg)
//     {
//         logo = lg;
//     }
// }

class Car
{
    public string logo;

    public Car(string lg)
    {
        logo = lg;
    } 
    public Car()
    {
    }
    ~Car()
    {
    }
}