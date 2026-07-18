namespace TLS_HX.Lesson11;

public class Lesson11
{
    public static void Run()
    {
        Console.WriteLine("内部类和分部类");

        Person p = new Person();
        p.age = 18;
        p.name = "张三";
        p.body = new Person.Body();
        p.body.leftArm = new Person.Body.Arm();
        p.body.rightArm = new Person.Body.Arm();
        
        Student student = new Student();
        student.name = "李四";
        student.sex = true;
        student.number = 123;
        student.Speak("Hello, World!");
    }
}

// 内部类
class Person
{
    public int age;
    public string name;
    public Body body;

    public class Body
    {
        public Arm leftArm;
        public Arm rightArm;
        public class Arm
        {

        }
    }
}

// 分部类
partial class Student
{
    public bool sex;
    public string name;

    partial void Speak();
}

partial class Student
{
    public int number;

    partial void Speak()
    {
        //实现逻辑
        
    }

    public void Speak(string text)
    {
        Console.WriteLine(text);
    }
}