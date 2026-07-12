---
tags:
  - 类型/知识点
  - 主题/集合
对应课件: Class02/Lesson13.cs
aliases:
  - List
---

# List&lt;T&gt; 泛型集合（列表）

> [!NOTE]
> 对应 `Class02/Lesson13.cs`。`List<T>` 是可变长的“动态数组”，是最常用的泛型集合。
> 前置：[泛型](./泛型.md) · [一维数组](../Class01-基础语法/一维数组.md) · 相关：[集合总览](./集合总览.md)

```csharp
using System.Collections.Generic;   // List<T> 所在命名空间

List<int> lst = new List<int>();     // 空列表，长度可动态增长
List<int> lst2 = new List<int>(2);   // 括号里的 2 是「初始容量」，不是长度

lst2.Add(2);          // 末尾添加 → [2]
lst2.Add(3);          // [2, 3]
lst2.Add(5);          // [2, 3, 5]
lst2.Insert(1, 10);   // 在下标 1 处插入 10 → [2, 10, 3, 5]
lst2.Clear();         // 清空 → []

for (int i = 0; i < lst2.Count; i++)   // Count 是元素个数（不是 Length）
{
    Console.WriteLine(lst2[i]);
}
```

## 要点

- `List<T>` 与数组的区别：**数组定长**，`List<T>` **可动态增删**。
  - `int[] a = new int[];` ❌ 数组必须指定长度会报错。
  - `List<int> l = new List<int>();` ✅ 不指定也行。
- 常用成员：
  - `Add(x)` 末尾添加；`Insert(i, x)` 指定位置插入；`Remove(x)` / `RemoveAt(i)` 删除；`Clear()` 清空。
  - **`Count`** 元素个数（数组用的是 `Length`，别搞混）。
  - `lst[i]` 用下标读写元素。
- 构造时 `new List<int>(2)` 的 `2` 是**初始容量**（预留空间的性能优化），**不是**元素个数，此时 `Count` 仍是 0。
- Python 对照：`List<T>` ≈ Python 的 `list`（但 C# 的 List 元素类型固定，编译期类型安全）。

## 优缺点

- ✅ 下标访问 `lst[i]` 快（内存连续，按「起点+偏移」直接定位）。
- ✅ 尾部 `Add` 快。
- ❌ 头部/中间 `Insert`/`Remove` 慢：后面的元素要**整体挪位**。
- 定位：**默认首选**的集合，90% 场景用它。各集合对比见[集合总览](./集合总览.md)。
