---
tags:
  - 类型/知识点
  - 主题/集合
对应课件: Class02/Lesson16.cs
aliases:
  - Dictionary
  - dict
  - 哈希表
---

# Dictionary&lt;TKey, TValue&gt; 字典

> [!NOTE]
> 对应 `Class02/Lesson16.cs`。字典 = **键值对集合**，按「键」存取值（≈ Python 的 `dict`）。
> 前置：[泛型](./泛型.md)（TKey/TValue 双类型参数）· [List 泛型集合](./List泛型集合.md) · 相关：[集合总览](./集合总览.md)

```csharp
Dictionary<string, int> ages = new Dictionary<string, int>();

ages["张三"] = 18;        // 推荐：索引器写法，有则改、无则加
ages["王五"] = 22;
ages["张三"] = 19;        // 键已存在 → 覆盖为 19
ages.Add("李四", 20);     // Add：重复键会抛异常，慎用

Console.WriteLine(ages["张三"]);              // 19，按键取值
Console.WriteLine(ages.ContainsKey("李四"));  // 是否有这个键

ages.Remove("李四");      // 按键删除

// 安全取值：键不存在时 ages["赵六"] 会抛异常
if (ages.TryGetValue("赵六", out int age)) { ... }

// 遍历：每个元素是 KeyValuePair
foreach (KeyValuePair<string, int> kv in ages)
{
    Console.WriteLine($"{kv.Key}: {kv.Value}");
}
```

## 要点

- 两个类型参数：`TKey` 键类型、`TValue` 值类型。
- **键不能重复**。由此的推荐原则：
  - **默认用 `dict[key] = value`**（有则改、无则加，永不报错）。
  - `Add` 遇重复键抛异常，仅在「重复键=程序错误，想立刻暴露」时用（快速失败）。
- 取不存在的键 `dict["x"]` 会抛异常 → 不确定时用 **`TryGetValue`** 或先 `ContainsKey`。
- 遍历元素类型是 `KeyValuePair<K,V>`，用 `.Key` / `.Value` 取。
- Python 对照：`Dictionary<K,V>` ≈ `dict`；`TryGetValue` ≈ `dict.get(key)`。

## 优缺点

- ✅ **按键查找极快**（哈希表实现，不用逐个遍历）。
- ❌ 键不能重复；元素没有下标/顺序概念。
- 用途：按名字查电话、按 ID 查对象——一切「查表」场景。
