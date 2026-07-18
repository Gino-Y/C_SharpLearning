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

[上一篇：Queue](./Queue队列.md) · [下一篇：Dictionary](./Dictionary字典.md)

> [!NOTE]
> 对应 `Class02/Lesson15.cs`。节点用前后指针串联，无下标。
> 前置：[List](./List泛型集合.md) · 相关枢纽：[集合选型](../枢纽/枢纽_集合选型.md)

```csharp
var list = new LinkedList<int>();
list.AddLast(1); list.AddFirst(0);
var node = list.Find(1);
list.AddAfter(node, 9); list.Remove(node);
```

| 方法 | 作用 |
|------|------|
| `AddFirst`/`AddLast` | 头尾添加 |
| `Find` / `AddAfter`/`AddBefore` | 定位节点后插 |
| `Remove` / `RemoveFirst`/`Last` | 删 |

- C# 的是**双向**链表（`Previous`/`Next`）。
- 已握节点时中间插删快；无下标访问慢。日常多用 List。
