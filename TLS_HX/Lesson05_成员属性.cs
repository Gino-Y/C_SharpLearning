namespace TLS_HX.Lesson05;

public class Lesson05
{
    public static void Run()
    {
        // 成员属性
        Person person = new Person();
        person.Name = "张三";
        person.Money = 100;
        Console.WriteLine($"{person.Name} has {person.Money} money");
        // person.Age = 18; // 报错，因为Age是只读的
        // person.Sex = true; // 报错，因为Sex是只读的
    }
}

class Person
{
    private string name;
    private int age;
    private int money;
    private bool sex;

    // 属性的命名规则：首字母大写
    public string Name
    {
        get
        {
            // 可以在获取之前添加逻辑规则
            return name;
        }
        set
        {
            // value 是关键字，表示赋值给属性的值
            // 可以在设置之前添加逻辑规则
            if (value.Length > 10)
            {
                Console.WriteLine("名字太长，请重新输入");
                return;
            }
            name = value;
        }
    }

    public int Money
    {
        get
        {
            // 解密处理
            return money - 5;
        }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("钱不能小于0，请重新输入");
                return;
            }
            // 加密处理
            money = value + 5;
        }
    }

    public bool Sex
    {
        // 只有一个没必要增加访问修饰符
        // 一般情况只会出现只有get没有set的属性
        get => sex;
    }

    // 希望外部能查不能改 有没特殊处理
    // 直接使用自动属性
    public int Age { get; private set; }
}