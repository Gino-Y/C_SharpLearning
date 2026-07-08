# C# 学习笔记

根据本项目 `Class01/`、`Class02/` 下的课程代码整理的学习笔记。

## 笔记目录

| 笔记 | 内容 | 对应代码 |
|------|------|----------|
| [01-基础语法](./01-基础语法.md) | 输出、变量、分支、循环、数组、方法 | `Class01/LessonXX.cs` |
| [02-面向对象](./02-面向对象.md) | 类与对象、构造函数、static、值/引用类型、继承与多态 | `Class02/LessonXX.cs` |

## 知识点速查

### Class01 基础语法

- **Lesson01/02** — 程序结构、命名空间、`Console.WriteLine`
- **Lesson11** — 变量、`if/else`、逻辑运算符、字符串插值 `$""`
- **Lesson12** — `switch` 分支（`break` 必写）
- **Lesson13** — `while` / `do-while`
- **Lesson14** — `for` / `foreach`
- **Lesson15** — 一维数组、初始化、遍历
- **Lesson16** — 二维数组 `int[,]` vs 交错数组 `int[][]`
- **Lesson17** — 方法、参数默认值、方法重载

### Class02 面向对象

- **Lesson01** — 类与对象、属性、`new`
- **Lesson04** — 构造函数、重载、默认构造函数陷阱
- **Lesson05** — `static` 静态成员与工具方法
- **Lesson06** — 值类型 vs 引用类型、栈与堆、传参
- **Lesson07 / 07b** — 继承、`virtual`/`override`/`abstract`、多态、里氏转换
- **IHotChair** — 接口 `interface`（一个类可实现多个接口，附加统一能力）
- **Lesson12** — 泛型 `<T>`、泛型方法、泛型约束 `where`、泛型类 `List<T>`

## 如何运行某节课

在 `Program.cs` 的 `Main` 里调用对应的 `Run()`（记得 `using` 对应命名空间），然后：

```bash
dotnet run
```

## 核心易错点回顾

- 命名空间两种写法（`namespace X;` 与 `namespace X {}`）**不能混用**。
- 语句（如 `foreach`、方法调用）只能写在**方法体内**，不能直接写在类体里。
- 二维数组 `int[,]` 用 `a[i, j]` 和 `GetLength(n)`；交错数组 `int[][]` 用 `a[i][j]` 和 `.Length`。
- 手写构造函数后，无参构造会消失，需要时要手动补。
- 静态成员用**类名**访问，实例成员用**对象**访问。
- 要 `override`，父类方法必须是 `virtual` 或 `abstract`。
