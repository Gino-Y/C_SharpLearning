namespace CSharpLearning.Class02_Practice1a;

public class Lesson19_Practice1a
{
    public static void Run()
    {
        // 练习：委托：智能家居遥控器
        // 生、定、被、调、创、注
        
        Light light = new Light();
        AirConditioner airConditioner = new AirConditioner();
        Speaker speaker = new Speaker();

        // 创建遥控器
        RemoteControl remoteControl = new RemoteControl();

        // 注册委托事件
        remoteControl.OnGoHome += light.TurnOn;
        remoteControl.OnGoHome += airConditioner.StartCool;
        remoteControl.OnGoHome += speaker.PlayMusic;

        remoteControl.PressButton();
    }
}

class RemoteControl
{
    // 声明委托类型
    public delegate void GoHomeHandler();

    // 定义委托变量
    public GoHomeHandler? OnGoHome;

    // 被注册的方法，执行时会调用委托事件
    public void PressButton()
    {
        Console.WriteLine(">>按下回家按钮<<");
        // 调用被注册的方法
        OnGoHome?.Invoke();
    }
}

class Light
{
    public void TurnOn()
    {
        Console.WriteLine("客厅亮了");
    }
}

class AirConditioner
{
    public void StartCool()
    {
        Console.WriteLine("空调制冷 26 度");
    }
}

class Speaker
{
    public void PlayMusic()
    {
        Console.WriteLine("音箱开始放歌");
    }
}