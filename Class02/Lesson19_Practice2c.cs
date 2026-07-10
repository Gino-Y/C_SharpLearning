namespace CSharpLearning.Class02_Practice1c;

public class Lesson19_Practice1a
{
    public static void Run()
    {
        // 练习：委托：智能家居遥控器

        light light = new light();
        airConditioner airConditioner = new airConditioner();
        speaker speaker = new speaker();

        RemoteControl remoteControl = new RemoteControl();
        remoteControl.OnGoHome += light.TurnOn;
        remoteControl.PressButton();
    }
}

class RemoteControl
{
    public delegate void GoHomeHandler();
    public GoHomeHandler? OnGoHome;

    public void PressButton()
    {
        Console.WriteLine(">>按下回家按钮<<");
        OnGoHome?.Invoke();
    }
}

class light
{
    public void TurnOn()
    {
        Console.WriteLine("客厅亮了");
    }
}

class airConditioner
{
    public void StartCool()
    {
        Console.WriteLine("空调制冷 26 度");
    }
}

class speaker
{
    public void PlayMusic()
    {
        Console.WriteLine("播放音乐");
    }
}