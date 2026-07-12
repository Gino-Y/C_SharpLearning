---
tags:
  - 类型/知识点
  - 主题/流程控制
对应课件: Class01/Lesson14.cs
aliases:
  - for
  - foreach
---

# for / foreach 循环

> [!NOTE]
> 对应 `Class01/Lesson14.cs`
> 前置：[while / do-while 循环](./while循环.md) · 相关：[一维数组](./一维数组.md)（foreach 最常遍历的对象）

```csharp
// for：适合按下标循环
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"i = {i}");
}

// foreach：适合遍历集合中每个元素
string[] names = { "Alice", "Bob", "Charlie" };
foreach (string name in names)
{
    Console.WriteLine($"name = {name}");
}
```

## 要点

- `for (初始化; 条件; 步进)`：能拿到下标 `i`，适合需要索引的场景。
- `foreach (类型 变量 in 集合)`：直接取每个元素，**拿不到下标**，写法更简洁。
- 只读取元素 → 用 `foreach`；需要下标或修改元素 → 用 `for`。
