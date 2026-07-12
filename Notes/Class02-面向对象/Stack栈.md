---
tags:
  - 类型/知识点
  - 主题/集合
---

# Stack&lt;T&gt; 栈

> 对应 `Class02/Lesson14a.cs`。栈 = **后进先出 LIFO**（像叠盘子，最后放的最先拿）。

```csharp
Stack<int> stack = new Stack<int>();

stack.Push(1);   // 入栈（压栈）
stack.Push(2);
stack.Push(3);   // 栈顶是 3

Console.WriteLine(stack.Peek());   // 3，只看栈顶，不取出
Console.WriteLine(stack.Pop());    // 3，出栈（弹栈）：取出栈顶
Console.WriteLine(stack.Pop());    // 2
Console.WriteLine(stack.Count);    // 1，剩 1 个
```

## 要点

- 术语：**Push = 入栈/压栈**（同义），**Pop = 出栈/弹栈**（同义）。
- `Peek` 只看栈顶不取出；`Pop` 取出并删除。
- `foreach` 遍历顺序是**从栈顶到栈底**，且不删除元素。
- 空栈调用 `Pop()`/`Peek()` 会抛异常；不确定时用 `TryPop`/`TryPeek`。

## 优缺点

- ✅ `Push`/`Pop` 只动**栈顶**一端，速度快。
- ❌ 没有下标，不能访问中间元素。
- 用途：撤销 (Ctrl+Z)、方法调用栈、括号匹配。
