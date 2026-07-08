# static 静态成员

> 对应 `Class02/Lesson05.cs`

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
