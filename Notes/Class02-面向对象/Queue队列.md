---
tags:
  - 类型/知识点
  - 主题/集合
---

# Queue&lt;T&gt; 队列

> 对应 `Class02/Lesson14b.cs`。队列 = **先进先出 FIFO**（像排队，先来的先走）。

```csharp
Queue<int> queue = new Queue<int>();

queue.Enqueue(1);   // 入队（排到队尾）
queue.Enqueue(2);
queue.Enqueue(3);   // 队首是 1，队尾是 3

Console.WriteLine(queue.Peek());      // 1，只看队首，不取出
Console.WriteLine(queue.Dequeue());   // 1，出队：取出队首
Console.WriteLine(queue.Dequeue());   // 2
Console.WriteLine(queue.Count);       // 1，剩 1 个
```

## 要点

- 术语：**Enqueue = 入队**（队尾进），**Dequeue = 出队**（队首出）。
- `Peek` 只看队首不取出。
- 和栈正好相反：栈取「最后放的」，队列取「最早放的」。

## 优缺点

- ✅ 入队/出队只动**队尾/队首**两端，速度快。
- ❌ 没有下标，不能访问中间元素。
- 用途：任务排队、消息队列、打印队列。
