using System;
using System.Collections.Generic;

namespace TLS_HX;

/// <summary>
/// 【场景 3】配置管理器
/// 
/// 知识点：
/// - 多参数索引器（索引器重载）
/// - 不同参数类型的索引器区分
/// - 字典初始化语法
/// 
/// 场景描述：
/// 配置系统（类似 appsettings.json）通过键访问配置值
/// 支持单参数读写和双参数带默认值的读取
/// </summary>
public class ConfigManager
{
    // 初始化配置字典
    private Dictionary<string, string> configs = new Dictionary<string, string>()
    {
        { "DatabaseUrl", "localhost:3306" },
        { "ApiTimeout", "30000" },
        { "MaxRetry", "3" },
        { "LogLevel", "Info" },
        { "Environment", "Development" }
    };

    /// <summary>
    /// 索引器 1：基础访问 - 通过键读写配置
    /// get：若键不存在返回空字符串
    /// set：新增或覆盖配置
    /// </summary>
    public string this[string key]
    {
        get { return configs.ContainsKey(key) ? configs[key] : ""; }
        set
        {
            if (configs.ContainsKey(key))
            {
                Console.WriteLine($"🔄 覆盖配置 [{key}]: {configs[key]} → {value}");
                configs[key] = value;
            }
            else
            {
                Console.WriteLine($"✓ 新增配置 [{key}] = {value}");
                configs.Add(key, value);
            }
        }
    }

    /// <summary>
    /// 索引器 2：带默认值的读取 - 多参数重载
    /// 若配置不存在，返回提供的默认值
    /// </summary>
    public string this[string key, string defaultValue]
    {
        get
        {
            if (configs.ContainsKey(key))
            {
                Console.WriteLine($"✓ 读取配置 [{key}] = {configs[key]}");
                return configs[key];
            }
            else
            {
                Console.WriteLine($"⚠ 配置 [{key}] 不存在，使用默认值 = {defaultValue}");
                return defaultValue;
            }
        }
    }

    /// <summary>显示所有配置</summary>
    public void Display()
    {
        Console.WriteLine("\n【配置列表】");
        foreach (var config in configs)
        {
            Console.WriteLine($"  {config.Key,-20} = {config.Value}");
        }
    }
}

// ============ 测试用例 ============
public class Scenario03
{
    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║   场景 3：配置管理器                    ║");
        Console.WriteLine("╚════════════════════════════════════════╝\n");

        ConfigManager config = new ConfigManager();

        Console.WriteLine("【查看初始配置】");
        config.Display();

        Console.WriteLine($"\n【读取配置 - 单参数】");
        Console.WriteLine($"  数据库地址：{config["DatabaseUrl"]}");
        Console.WriteLine($"  API 超时：{config["ApiTimeout"]}");

        Console.WriteLine($"\n【读取配置 - 双参数（带默认值）】");
        string maxConn = config["MaxConnections", "10"];  // 不存在，用默认值
        Console.WriteLine($"  最大连接数：{maxConn}");

        string port = config["Port", "5000"];
        Console.WriteLine($"  服务端口：{port}");

        Console.WriteLine($"\n【修改配置】");
        config["DatabaseUrl"] = "192.168.1.100:3306";
        config["Environment"] = "Production";

        Console.WriteLine($"\n【新增配置】");
        config["JwtSecret"] = "super_secret_key_2024";
        config["MaxRetry"] = "5";  // 覆盖

        config.Display();
    }
}
