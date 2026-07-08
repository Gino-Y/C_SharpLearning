namespace CSharpLearning.Class02;

public class Lesson16
{
    public static void Run()
    {
        // Dictionary<TKey, TValue> 字典：按「键」存取值（键值对集合）
        // 优点：按键查找极快；缺点：键不能重复、无顺序概念
        Dictionary<string, int> ages = new Dictionary<string, int>();

        // 推荐：默认用索引器写法 dict[key] = value（有则改、无则加，不报错）
        ages["张三"] = 18;
        ages["王五"] = 22;
        ages["张三"] = 19;        // 键已存在 → 覆盖为 19

        // Add 也能添加，但遇到重复键会抛异常，所以不作为默认写法
        // 适用场景：重复键=程序错误，希望立刻报错暴露问题（快速失败）
        ages.Add("李四", 20);          // ✅ "李四"不存在，添加成功
        // ages.Add("张三", 25);       // ❌ "张三"已存在，抛 ArgumentException

        Console.WriteLine(ages["张三"]);          // 19，按键取值
        Console.WriteLine(ages.Count);            // 3
        Console.WriteLine(ages.ContainsKey("李四"));   // True，是否有这个键

        ages.Remove("李四");      // 按键删除

        // 安全取值：键不存在时 ages["赵六"] 会抛异常，用 TryGetValue 更稳
        if (ages.TryGetValue("赵六", out int age))
        {
            Console.WriteLine(age);
        }
        else
        {
            Console.WriteLine("没有赵六这个键");
        }

        // 遍历：每个元素是一个键值对 KeyValuePair
        foreach (KeyValuePair<string, int> kv in ages)
        {
            Console.WriteLine($"{kv.Key}: {kv.Value}");   // 张三: 19  王五: 22
        }
    }
}
