---
tags:
  - 类型/知识点
  - 主题/流程控制
对应课件: Class01/Lesson12.cs
aliases:
  - switch
---

# switch 分支

> [!NOTE]
> 对应 `Class01/Lesson12.cs`
> 前置：[变量与条件分支](./变量与条件分支.md) · 相关：[enum 枚举](../Class02-面向对象/枚举.md)（switch 的最佳拍档）

```csharp
int a = 9;
switch (a)
{
    case 0:
        Console.WriteLine("a == 0");
        break;
    case 1:
        Console.WriteLine("a == 1");
        break;
    default:
        Console.WriteLine("a == ?");
        break;
}
```

## 要点

- 每个 `case` 后**必须有 `break;`**（否则编译错误，C# 不允许自动“贯穿”）。
- `default` 处理所有未匹配的情况。
- 多个固定取值的判断，用 `switch` 比一长串 `if-else` 清晰。
