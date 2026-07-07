namespace CSharpLearning.Class02;

public class Lesson01
{
    public static void Run()
    {
        // 面向对象：类
        // Console.WriteLine("Class02");
        Student student = new Student();
        student.Name = "张三";
        student.Age = 18;
        student.Gender = "男";
        student.Class = "1班";
        student.School = "北京大学";
        student.Teacher = "李老师";
        Console.WriteLine(student.Name);
        Console.WriteLine(student.Age);
        Console.WriteLine(student.Gender);
        Console.WriteLine(student.Class);
        Console.WriteLine(student.School);
        Console.WriteLine(student.Teacher);
        
        Student student2 = new Student();
        student2.Name = "李四";
        student2.Age = 19;
        student2.Gender = "女";
        student2.Class = "2班";
        student2.School = "清华大学";
        student2.Teacher = "王老师";
        Console.WriteLine(student2.Name);
        Console.WriteLine(student2.Age);
        Console.WriteLine(student2.Gender);
        Console.WriteLine(student2.Class);
        Console.WriteLine(student2.School);
        Console.WriteLine(student2.Teacher);
    }
}

class Student
{
    // 属性
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Class { get; set; }
    public string School { get; set; }
    public string Teacher { get; set; }
}

