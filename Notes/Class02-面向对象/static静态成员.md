---
tags:
  - 类型/知识点
  - 主题/类与对象
---

# static 静态成员与静态类

> 对应 `Class02/Lesson05.cs`（小M老师课程）、`TLS_HX/Lesson08_Practice1.cs`（唐老师核心课程·方法练习）

```csharp
public class Dog
{
    public int Age { get; set; }        // 实例成员：每个对象各一份
    public static int num { get; set; } // 静态成员：全类共享一份
}

// 使用：
dog1.Age = 3;                // 实例成员用「对象」访问
Dog.num++;                   // 静态成员用「类名」访问
int c = NumTool.Add(3, 5);   // 静态方法不用 new
```

## 要点

- **`static` = 属于类本身**；不带 static（实例）= 属于每个对象。
- 访问方式：静态 → **类名.成员**；实例 → **对象.成员**。
- 静态字段**全类共享一份**、贯穿程序生命周期（常用作计数器）。
- 静态方法适合做**工具函数**（如 `Math.Max`、`Console.WriteLine`），不依赖具体对象。
- 陷阱：静态方法里**不能直接访问实例成员**（没有具体对象）。
- `Main` / `Run` 必须是 static——程序启动时还没有任何对象。
- Python 对照：类变量 ≈ static 字段；`@staticmethod` ≈ 静态方法。

## 静态工具类实战（TLS_HX 方法练习）

`class` 前也加 `static` = **静态类**：只放静态成员、禁止 new（`Math`、`Console` 都是）。完整代码见 `TLS_HX/Lesson08_Practice1.cs`。

```csharp
static class MathTool
{
    /// <summary>计算绝对值</summary>          ← XML 文档注释：IDE 悬停显示说明
    /// <param name="number">值</param>
    public static float GetABS(float number)
    {
        return number >= 0 ? number : -number;   // 三元运算符：4 行 if/else 压成 1 行
    }
}
MathTool.GetABS(-10);   // 类名直接点，不用 new
```

- 踩坑：绝对值写 `> 0` → 传 0 输出 `-0` → `float` 是 IEEE 754，存在真负零；改 `>=` 即可（`int` 无此问题）。

## 知识链：下一步 → 拓展方法

静态成员 → 静态方法（工具函数） → 静态类（工具类） → [拓展方法](./拓展方法.md)：静态方法第一个参数加 `this`，调用从 `MathTool.GetABS(x)` 变成 `x.GetABS()`。
