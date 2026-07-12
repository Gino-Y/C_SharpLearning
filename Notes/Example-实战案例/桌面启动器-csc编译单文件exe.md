# 实战：桌面启动器（csc 编译单文件 exe）

> 对应 `Example/Launcher.cs`。双击桌面的 `C#课程.exe` 自动打开 Chrome 书签页。串起**编译原理、进程启动、模拟按键**三个知识点。

## 核心代码

完整源码见 `Example/Launcher.cs`，骨架：

```csharp
[STAThread]
static void Main()
{
    // Chrome 会忽略命令行传入的 chrome:// 内部地址，所以开空窗口后模拟按键输入
    Process.Start(new ProcessStartInfo
    {
        FileName = "chrome.exe",              // Windows 经注册表 App Paths 自动定位
        Arguments = "--new-window about:blank",
        UseShellExecute = true
    });
    Thread.Sleep(2500);                       // 等窗口获得焦点
    Clipboard.SetText("chrome://bookmarks/?id=3662");   // 用前备份、用后还原（略）
    SendKeys.SendWait("^l");                  // Ctrl+L 聚焦地址栏
    SendKeys.SendWait("^v");                  // Ctrl+V 粘贴（防中文输入法拦截字母）
    SendKeys.SendWait("{ENTER}");
}
```

## 怎么编译（csc 单文件编译）

```powershell
csc.exe /target:winexe /r:System.Windows.Forms.dll /out:"桌面\C#课程.exe" Launcher.cs
```

- `csc` = C# 编译器，Windows 自带；`/target:winexe` 双击不闪控制台；`/r:` 引用 WinForms 库。
- 编译完 exe 独立，**运行不需要源码**；改功能要改源码重新编译。

## 编译 vs 构建

| | 课程项目 | 这个启动器 |
|---|---|---|
| 命令 | `dotnet build` / `dotnet run` | `csc Launcher.cs` |
| 过程 | 构建：读 `.csproj` → 还原依赖 → 编译全部 `.cs` → 输出 `bin/` | 编译：单文件直接翻译成 exe |

**编译是核心动作，构建 = 编译 + 项目管理的一整套流程。**

```
源码 .cs ──编译(csc)──► exe（IL 中间语言）──运行时 JIT──► 机器码
```

- 编译时完成语法/类型检查（比 Python 早发现错误）；exe 里是 IL 所以只有 4KB，.NET 运行时是 Windows 自带的。C/C++ 编译成纯机器码；Python 解释执行。

## 踩过的坑

1. `chrome://` 地址命令行打不开 → Chrome 安全限制（https:// 可以）→ 改模拟按键+剪贴板方案
2. 源码放进课程项目报错 → 自带 `Main` 撞入口 + 缺 WinForms 引用 → `.csproj` 加 `<Compile Remove="Example\**" />` 排除
3. 提交出去个空文件 → IDE 不实时写盘 → 提交前先 Ctrl+S

## 要点

- `Process.Start` + `ProcessStartInfo`：启动外部程序、传命令行参数。
- `SendKeys.SendWait`：模拟按键（`^l`=Ctrl+L，`{ENTER}`=回车），`Main` 需标 `[STAThread]`。
- `Clipboard`：读写系统剪贴板，用前备份、用后还原。
- 一个 `.cs` 文件也能直接编译成可双击的 exe，不一定要建项目。
