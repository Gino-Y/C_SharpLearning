# 实战：桌面启动器（csc 编译单文件 exe）

> 对应 `Example/Launcher.cs`。一个十几行的小程序：双击桌面的 `C#课程.exe`，自动打开 Chrome 书签页 `chrome://bookmarks/?id=3662`。麻雀虽小，串起了**编译原理、进程启动、模拟按键**三个知识点。

## 源码

```csharp
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

class Launcher
{
    // Chrome 出于安全考虑，会忽略命令行传入的 chrome:// 内部地址（实测只会开新标签页）
    // 所以改用模拟按键：开新窗口 → Ctrl+L 聚焦地址栏 → Ctrl+V 粘贴地址 → 回车
    [STAThread]
    static void Main()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "chrome.exe",               // Windows 通过注册表 App Paths 自动定位
            Arguments = "--new-window about:blank",
            UseShellExecute = true
        });

        Thread.Sleep(2500);   // 等 Chrome 窗口出现并获得焦点

        // 备份剪贴板，用完还原；用粘贴而不是逐字输入，避免中文输入法拦截字母
        string old = Clipboard.ContainsText() ? Clipboard.GetText() : null;

        Clipboard.SetText("chrome://bookmarks/?id=3662");
        SendKeys.SendWait("^l");        // Ctrl+L 聚焦地址栏
        SendKeys.SendWait("^v");        // Ctrl+V 粘贴
        SendKeys.SendWait("{ENTER}");

        Thread.Sleep(500);
        if (old != null) Clipboard.SetText(old);
    }
}
```

## 怎么编译（csc 单文件编译）

```powershell
csc.exe /target:winexe /r:System.Windows.Forms.dll /out:"桌面\C#课程.exe" Launcher.cs
```

- `csc` = C# Compiler，Windows 自带（`C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe`）。
- `/target:winexe`：窗口程序，双击时不闪黑色控制台。
- `/r:System.Windows.Forms.dll`：引用 WinForms 库（剪贴板、SendKeys 在里面）。
- 编译完 exe 就独立了，**运行不再需要源码**；想改功能（如换网址）要改源码重新编译。

## 编译 vs 构建

| | 课程项目 | 这个启动器 |
|---|---|---|
| 命令 | `dotnet build` / `dotnet run` | `csc Launcher.cs` |
| 过程 | 构建：读 `.csproj` → 还原依赖 → 编译全部 `.cs` → 输出到 `bin/` | 编译：单文件直接翻译成 exe |

**编译是核心动作，构建 = 编译 + 项目管理的一整套流程。**

C# 的完整执行链条（半编译半翻译）：

```
源码 .cs ──编译(csc)──► exe（装的是 IL 中间语言）──运行时 JIT──► 机器码（CPU 执行）
```

- 编译时做完语法/类型检查（比 Python 早发现错误）；exe 里是 IL 不是纯机器码，所以只有 4KB——真正干活的 .NET 运行时是 Windows 自带的。
- 对比：C/C++ 编译成纯机器码；Python 不编译、解释器逐条执行。

## 踩过的坑

1. **`chrome://` 内部地址不能从命令行打开**：Chrome 出于安全会忽略它（普通 https:// 网址可以）。用调试接口实测确认后，改成「模拟按键 + 剪贴板粘贴」方案。
2. **源码放进课程项目会报错**：`Launcher.cs` 自带 `Main`，和 `Program.cs` 入口冲突；且课程项目没引用 WinForms。解决：在 `.csproj` 里排除整个文件夹——

```xml
<ItemGroup>
  <Compile Remove="Example\**" />
</ItemGroup>
```

3. **提交前记得 Ctrl+S**：IDE 不实时写盘，曾把未保存的空文件 commit 了出去。

## 要点

- `Process.Start` + `ProcessStartInfo`：从 C# 启动外部程序、传命令行参数。
- `SendKeys.SendWait`：模拟键盘按键（`^l` = Ctrl+L，`{ENTER}` = 回车），需要 `[STAThread]` 标注 `Main`。
- `Clipboard`：读写系统剪贴板，用前备份、用后还原是好习惯。
- 一个 `.cs` 文件也能直接编译成能双击的 exe，不一定非要建项目。
