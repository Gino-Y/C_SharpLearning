using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

class Launcher
{
    // Chrome 出于安全考虑，会忽略命令行传入的 chrome:// 内部地址（实测只会开新标签页）
    // 所以改用模拟按键：开新窗口 → Ctrl+L 聚焦地址栏 → Ctrl+V 粘贴地址 → 回车
    // 用剪贴板粘贴而不是逐字输入，是为了避免中文输入法拦截字母
    [STAThread]
    static void Main()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "chrome.exe",
            Arguments = "--new-window about:blank",
            UseShellExecute = true
        });

        Thread.Sleep(2500);   // 等 Chrome 窗口出现并获得焦点

        // 先备份用户剪贴板里的文字，用完再还原
        string old = Clipboard.ContainsText() ? Clipboard.GetText() : null;

        Clipboard.SetText("chrome://bookmarks/?id=3662");
        SendKeys.SendWait("^l");        // Ctrl+L 聚焦地址栏
        SendKeys.SendWait("^v");        // Ctrl+V 粘贴
        SendKeys.SendWait("{ENTER}");

        Thread.Sleep(500);
        if (old != null) Clipboard.SetText(old);
    }
}
