---
tags:
  - 类型/知识点
  - 主题/集合
对应课件: Class02/Lesson15.cs
aliases:
  - LinkedList
  - 链表
---

# LinkedList&lt;T&gt; 链表

> [!NOTE]
> 对应 `Class02/Lesson15.cs`。链表 = 节点用**前后指针**串起来，没有下标。
> 前置：[List 泛型集合](./List泛型集合.md)（对照：连续内存 vs 指针串联）· 相关：[集合总览](./集合总览.md)

```csharp
LinkedList<int> list = new LinkedList<int>();

list.AddLast(1);    // 加到尾部
list.AddLast(2);    // 1 -> 2
list.AddFirst(0);   // 加到头部：0 -> 1 -> 2

Console.WriteLine(list.First.Value);          // 0，头节点
Console.WriteLine(list.Last.Value);           // 2，尾节点
Console.WriteLine(list.Last.Previous.Value);  // 1，双向的体现：从尾往回走

// 中间插入/删除：先 Find 找到节点，再在它前后操作
LinkedListNode<int> node = list.Find(1);
list.AddAfter(node, 9);    // 0 -> 1 -> 9 -> 2
list.AddBefore(node, 7);   // 0 -> 7 -> 1 -> 9 -> 2
list.Remove(node);         // 0 -> 7 -> 9 -> 2
list.Remove(9);            // 按值删第一个匹配：0 -> 7 -> 2

list.RemoveFirst();   // 删头
list.RemoveLast();    // 删尾
```

## 单向 vs 双向链表

- **单向链表**：节点只有 `Next`，只能从头往尾走。
- **双向链表**：节点有 `Prev` + `Next`，可双向遍历、可直接找前一个节点。
- **C# 的 `LinkedList<T>` 是双向链表**，节点类型 `LinkedListNode<T>`（有 `Previous`/`Next`）。

## 常用方法

| 方法 | 作用 |
|------|------|
| `AddFirst` / `AddLast` | 头/尾添加 |
| `Find(值)` | 找到第一个匹配的**节点** |
| `AddAfter(节点, 值)` / `AddBefore(节点, 值)` | 在节点后/前插入 |
| `Remove(节点)` / `Remove(值)` | 删除 |
| `First` / `Last`、`RemoveFirst` / `RemoveLast` | 头尾访问/删除 |

## 优缺点

- ✅ 任意位置插入/删除快：只改前后指针，**不挪元素**。
- ❌ 访问慢：没有下标，找第 n 个要从头逐个数（`Find` 也是逐个找）。
- 注意：「中间操作快」的前提是**已握着节点**；每次都靠 `Find` 的话，查找本身是慢的那步。
- 用途较少：频繁在中间增删时才有优势，日常大多用 `List<T>`。
