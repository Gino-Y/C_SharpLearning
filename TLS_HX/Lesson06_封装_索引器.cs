namespace TLS_HX.Lesson06;

public class Lesson06
{
    public static void Run()
    {
        //总结：索引器的主要作用
        //可以让我们以中括号的形式【访问】自定义类中的元素 规则自己定 访问时和数组一样
        //比较适用于 在类中有数组变量时使用 可以方便的访问和进行逻辑处理

        //固定写法
        //访问修饰符 返回值 this[参数列表]
        //get和set语句块
        //可以重载

        //注意：结构体里面也是支持索引器
        Console.WriteLine("索引器");

        #region 知识点三 索引器的使用
        Person p = new Person();

        // 像数组一样用中括号访问对象（走 this[int]）
        p[0] = new Person();
        Console.WriteLine(p[0]);        // TLS_HX.Lesson06.Person

        // 重载版本（走 this[int, int]）：读写内部二维数组
        p[0, 0] = 10;
        Console.WriteLine(p[0, 0]);     // 10

        // 重载版本（走 this[string]）：按名字取字段
        Console.WriteLine(p["name"]);   // 唐老师
        #endregion
    }
}

#region 知识回顾
class 类名
{
    #region 特征——成员变量
    #endregion

    #region 行为——成员方法
    #endregion

    #region 初始化调用——构造方法
    #endregion

    #region 释放时调用——析构方法
    #endregion

    #region 保护成员变量用——成员属性
    #endregion
}
#endregion

#region 知识点一 索引器基本概念
//基本概念
//让对象可以像数组一样通过索引访问其中元素，使程序看起来更直观，更容易编写
#endregion

#region 知识点二 索引器语法
//访问修饰符 返回值 this[参数类型 参数名, 参数类型 参数名.....]
//{
//      内部的写法和规则与【成员属性】相同
//      get{}
//      set{}       value 代表传入的值
//}
#endregion

class Person
{
    private string name = "唐老师";
    private int age;
    private Person[] friends;

    // 数组是引用类型，不 new 默认是 null，索引器一写就抛 NullReferenceException
    private int[,] array = new int[10, 10];

    // 基础版：一个 int 参数，访问 friends 数组
    public Person this[int index]
    {
        get
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index);   // 负数索引直接报错

            #region 知识点四 索引器中可以写逻辑（规则自己定）
            if (friends == null || friends.Length - 1 < index)
            {
                return null;    // 没有朋友或越界：返回 null 而不是抛异常
            }
            #endregion
            return friends[index];
        }
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index);

            if (friends == null)
            {
                friends = new Person[] { value };       // 还没有数组：新建
            }
            else if (index > friends.Length - 1)
            {
                friends[friends.Length - 1] = value;    // 越界：自定规则，顶掉最后一个朋友
            }
            else
            {
                friends[index] = value;                 // 正常写入
            }
        }
    }

    #region 知识点五 索引器可以重载
    //重载的概念是——函数名相同（都是 this） 参数类型、数量、顺序不同

    // 参数【数量】不同：二维索引，读写内部二维数组
    public int this[int i, int j]
    {
        get { return array[i, j]; }
        set { array[i, j] = value; }
    }

    // 参数【类型】不同：按字符串取字段（只读，可以只有 get）
    public string this[string str]
    {
        get
        {
            switch (str)
            {
                case "name": return name;
                case "age": return age.ToString();
            }
            return "";
        }
    }
    #endregion
}
