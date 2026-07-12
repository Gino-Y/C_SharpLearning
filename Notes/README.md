# C# 学习笔记

根据本项目 `Class01/`、`Class02/`（小M老师课程）、`TLS_HX/`（唐老师C#核心课程）、`Example/` 下的课程代码整理。TLS_HX 的内容按知识点就近合并进对应笔记。

## 笔记组织方式

- **一个知识点 = 一个独立文件**，放在对应模块的子文件夹里。
- 模块索引文件（本文件、`01-基础语法.md`、`02-面向对象.md`）只做**标题、概述、引用**，不堆内容。

## 模块索引

- [01 · 基础语法（Class01）](./01-基础语法.md) — 输出、变量、分支、循环、数组、方法
- [02 · 面向对象（Class02）](./02-面向对象.md) — 类、构造函数、static、值/引用类型、继承、多态、接口、泛型、集合

## 知识点速查

### Class01 基础语法
- [程序结构与输出](./Class01-基础语法/程序结构与输出.md)
- [变量与条件分支（if）](./Class01-基础语法/变量与条件分支.md)
- [switch 分支](./Class01-基础语法/switch分支.md)
- [while / do-while 循环](./Class01-基础语法/while循环.md)
- [for / foreach 循环](./Class01-基础语法/for与foreach循环.md)
- [一维数组](./Class01-基础语法/一维数组.md)
- [二维数组与交错数组](./Class01-基础语法/二维与交错数组.md)
- [方法与方法重载](./Class01-基础语法/方法与方法重载.md)

### Class02 面向对象
- [类与对象](./Class02-面向对象/类与对象.md)
- [构造函数](./Class02-面向对象/构造函数.md)
- [static 静态成员与静态类](./Class02-面向对象/static静态成员.md)
- [值类型 vs 引用类型](./Class02-面向对象/值类型与引用类型.md)
- [继承、多态、抽象类](./Class02-面向对象/继承与多态.md)
- [接口 interface](./Class02-面向对象/接口.md)
- [泛型 Generics](./Class02-面向对象/泛型.md)
- [List&lt;T&gt; 泛型集合](./Class02-面向对象/List泛型集合.md)
- [Stack&lt;T&gt; 栈](./Class02-面向对象/Stack栈.md)
- [Queue&lt;T&gt; 队列](./Class02-面向对象/Queue队列.md)
- [LinkedList&lt;T&gt; 链表](./Class02-面向对象/LinkedList链表.md)
- [Dictionary&lt;K,V&gt; 字典](./Class02-面向对象/Dictionary字典.md)
- [集合总览](./Class02-面向对象/集合总览.md)
- [struct 结构体](./Class02-面向对象/结构体.md)
- [enum 枚举](./Class02-面向对象/枚举.md)
- [拓展方法](./Class02-面向对象/拓展方法.md)
- [运算符重载](./Class02-面向对象/运算符重载.md)
- [delegate 委托](./Class02-面向对象/委托.md)
- [委托练习 1](./Class02-面向对象/委托-练习1.md)
- [委托练习 2](./Class02-面向对象/委托-练习2.md)
- [委托练习 3](./Class02-面向对象/委托-练习3.md)

### Example 实战案例
- [桌面启动器：csc 编译单文件 exe](./Example-实战案例/桌面启动器-csc编译单文件exe.md)

## 如何运行某节课

在 `Program.cs` 的 `Main` 里调用对应的 `Run()`（记得 `using` 对应命名空间），然后：

```bash
dotnet run
```
