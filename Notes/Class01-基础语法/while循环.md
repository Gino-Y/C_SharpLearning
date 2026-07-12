---
tags:
  - 类型/知识点
  - 主题/流程控制
对应课件: Class01/Lesson13.cs
aliases:
  - while
  - do-while
---

# while / do-while 循环

> [!NOTE]
> 对应 `Class01/Lesson13.cs`
> 前置：[变量与条件分支](./变量与条件分支.md) · 相关：[for / foreach 循环](./for与foreach循环.md)

```csharp
int num = 6;
do
{
    Console.WriteLine($"num = {num}");
    num++;
} while (num < 5);        // 注意结尾有分号
```

## 要点

- `while (条件) { }`：**先判断**再执行，条件不成立一次都不跑。
- `do { } while (条件);`：**先执行一次**再判断，所以即使 `num=6` 不满足 `<5`，也会打印一次。
- `do-while` 结尾的分号 `;` 不能忘。
