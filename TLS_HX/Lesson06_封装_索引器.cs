namespace TLS_HX.Lesson06;

// 索引器：让对象像数组一样用中括号访问。概念、语法、要点见笔记《索引器》
public class Lesson06
{
    public static void Run()
    {
        Person p = new Person();

        // 基础版 this[int]：访问对象内部的 friends 数组
        p[0] = new Person();
        Console.WriteLine(p[0]);        // TLS_HX.Lesson06.Person

        // 重载 this[int, int]：读写内部二维数组
        p[0, 0] = 10;
        Console.WriteLine(p[0, 0]);     // 10

        // 重载 this[string]：按名字取字段
        Console.WriteLine(p["name"]);   // 唐老师
    }
}

class Person
{
    private string name = "唐老师";
    private int age;
    private Person[] friends;
    private int[,] array = new int[10, 10];   // 不 new 默认 null，索引器一写就抛异常

    #region 基础索引器 this[int]
    public Person this[int index]
    {
        get
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index);
            if (friends == null || friends.Length - 1 < index)
            {
                return null;            // 规则自己定：没有朋友或越界，返回 null 不抛异常
            }
            return friends[index];
        }
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index);
            if (friends == null)
            {
                friends = new Person[] { value };
            }
            else if (index > friends.Length - 1)
            {
                friends[friends.Length - 1] = value;   // 规则自己定：越界顶掉最后一个朋友
            }
            else
            {
                friends[index] = value;
            }
        }
    }
    #endregion

    #region 重载：参数数量不同 this[int, int]
    public int this[int i, int j]
    {
        get { return array[i, j]; }
        set { array[i, j] = value; }
    }
    #endregion

    #region 重载：参数类型不同 this[string]（只读，可只有 get）
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
