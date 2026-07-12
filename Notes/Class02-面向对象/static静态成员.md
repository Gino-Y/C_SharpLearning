# static 静态成员与静态类

> 对应 `Class02/Lesson05.cs`（小M老师课程）、`TLS_HX/Lesson08_Practice1.cs`（唐老师核心课程·方法练习）

```csharp
public class Dog : Animal
{
    public int Age { get; set; }        // 实例成员：每个对象各一份
    public static int num { get; set; } // 静态成员：全类共享一份
}

class NumTool
{
    public static int Add(int a, int b) => a + b;   // 静态方法（工具）
}

// 使用：
Dog dog1 = new Dog();
dog1.Age = 3;        // 实例成员用「对象」访问
Dog.num++;           // 静态成员用「类名」访问
int c = NumTool.Add(3, 5);   // 静态方法不用 new
```

## 要点

- **`static`（静态）= 属于类本身**；不带 static（实例）= 属于每个对象。
- 访问方式：
  - 静态成员 → **类名.成员**（`Dog.num`）
  - 实例成员 → **对象.成员**（`dog1.Age`）
- 静态字段**全类共享一份**、贯穿整个程序生命周期（常用作计数器）。
- 静态方法适合做**工具函数**（如 `Math.Max`、`Console.WriteLine`），不依赖具体对象。
- 陷阱：**静态方法里不能直接访问实例成员**（因为没有具体对象）。
- `Main` / `Run` 必须是 static，因为程序启动时还没有任何对象。
- Python 对照：类变量 ≈ static 字段；`@staticmethod` ≈ 静态方法。

## 静态工具类实战（TLS_HX 方法练习）

工具类可以在 `class` 前也加 `static`，表示**整个类只放静态成员、禁止 new**：

```csharp
static class MathTool
{
    /// <summary>
    /// 计算圆的面积
    /// </summary>
    /// <param name="radius">半径</param>
    /// <returns>面积</returns>
    public static float CalcCircularArea(float radius)
    {
        return (float)(Math.PI * radius * radius);
    }

    public static float GetABS(float number)
    {
        return number >= 0 ? number : -number;   // 注意是 >=，见下方踩坑
    }
}

// 调用：类名直接点，不用 new
MathTool.GetABS(-10);
```

- `static class`：编译器强制类里所有成员都是 static，`new MathTool()` 直接报错。`Math`、`Console` 都是这种类。
- `/// <summary>` 是 **XML 文档注释**：写在方法上方，说明方法用途、`<param>` 参数、`<returns>` 返回值。IDE 里鼠标悬停在调用处就会弹出这些说明，团队协作必备。
- `number >= 0 ? number : -number` 用了三元运算符，相当于 4 行 if/else 压缩成 1 行。

### 踩坑：float 的负零

绝对值最初写的是 `number > 0 ? number : -number`，传入 `0` 时走了 `-number` 分支，输出 `-0`——因为 `float` 是 IEEE 754 浮点数，**存在真正的"负零"**（符号位为 1 的零）。改成 `>=` 让 0 走原样返回的分支即可。整数 `int` 没有负零，不会出这个问题。

## 知识链：下一步 → 拓展方法

```
静态成员 → 静态方法（工具函数） → 静态类（工具类） → 拓展方法
```

静态类里的静态方法，如果把**第一个参数用 `this` 修饰**，就升级成了「拓展方法」——调用方式从 `MathTool.GetABS(x)` 变成 `x.GetABS()`，像类型自带的方法一样。详见 [拓展方法](./拓展方法.md)。
