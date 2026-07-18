---
tags:
  - 类型/实战
  - 主题/工具链
对应课件: Example/Launcher.cs
aliases:
  - csc
  - Launcher
---

# 实战：桌面启动器（csc 编译单文件 exe）

> [!NOTE]
> 对应 `Example/Launcher.cs`。双击 `C#课程.exe` 打开 Chrome 书签页。
> 前置：[程序结构与输出](../Class01-基础语法/程序结构与输出.md) · [static](../Class02-面向对象/static静态成员.md)

## 核心代码

完整见 `Example/Launcher.cs`：

```csharp
[STAThread]
static void Main()
{
    Process.Start(new ProcessStartInfo {
        FileName = "chrome.exe",
        Arguments = "--new-window about:blank",
        UseShellExecute = true
    });
    Thread.Sleep(2500);
    Clipboard.SetText("chrome://bookmarks/?id=3662");
    SendKeys.SendWait("^l");   // Ctrl+L
    SendKeys.SendWait("^v");
    SendKeys.SendWait("{ENTER}");
}
```

## 编译

```powershell
csc.exe /target:winexe /r:System.Windows.Forms.dll /out:"桌面\C#课程.exe" Launcher.cs
```

- `/target:winexe` 无控制台；编译出独立 exe。`dotnet build` = 项目管理+编译；本例是单文件 `csc`。
- 产出是 IL，运行时 JIT；语法错误在编译期发现。

## 踩过的坑

> [!WARNING]
> - `chrome://` 命令行打不开 → 安全限制 → 模拟按键+剪贴板。
> - 源码进主项目撞 `Main`/缺 WinForms → `.csproj` 加 `<Compile Remove="Example\**" />`。
> - 提交空文件 → 先 Ctrl+S。

## 要点

- `Process.Start` 启外部程序；`SendKeys` 需 `[STAThread]`；`Clipboard` 用前备份用后还原。
