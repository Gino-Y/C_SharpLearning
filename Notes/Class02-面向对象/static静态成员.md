---
tags:
  - 类型/知识点
  - 主题/类与对象
对应课件:
  - Class02/Lesson05.cs
  - TLS_HX/Lesson08_Practice1.cs
aliases:
  - static
  - 静态类
---

# static 静态成员与静态类

[上一篇：构造函数](./构造函数.md) · [下一篇：成员属性](./成员属性.md)

> [!NOTE]
> 对应 `Class02/Lesson05.cs`、`TLS_HX/Lesson08_Practice1.cs`。
> 前置：[类与对象](./类与对象.md) · 相关：[拓展方法](./拓展方法.md)

```csharp
public class Dog {
    public int Age { get; set; }         // 实例：每对象一份
    public static int num { get; set; }  // 静态：全类共享
}
dog1.Age = 3; Dog.num++; NumTool.Add(3, 5);  // 静态用类名，不用 new
```

## 要点

- 静态属类；实例属对象。静态字段全类一份；静态方法适合工具函数。
- 静态方法内不能直接访问实例成员；`Main`/`Run` 必须 static。
- `static class`：只静态成员、禁 new（如 `Math`）。

```csharp
static class MathTool {
    /// <summary>绝对值</summary>
    public static float GetABS(float n) => n >= 0 ? n : -n;
}
```

> [!WARNING]
> 绝对值写 `> 0` → 传 0 得 `-0`（float 负零）→ 改 `>=`。

知识链 → [拓展方法](./拓展方法.md)：首参加 `this`，`MathTool.GetABS(x)` → `x.GetABS()`。

> [!TIP]
> Python：类变量 ≈ static 字段；`@staticmethod` ≈ 静态方法。
