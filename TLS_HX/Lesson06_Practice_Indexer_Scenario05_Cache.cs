using System;
using System.Collections.Generic;

namespace TLS_HX.Lesson06_Indexer_Practice
{
    /// <summary>
    /// 【场景 5】缓存系统（带过期时间）
    /// 
    /// 知识点：
    /// - 元组（Tuple）存储关联数据
    /// - DateTime 时间比较与过期检查
    /// - 索引器与自动清理逻辑的结合
    /// - 缓存策略的实现思路
    /// 
    /// 场景描述：
    /// 简易缓存系统，存储键值对和过期时间
    /// 读取时自动检查是否过期，过期数据自动删除
    /// 
    /// 运行方式：
    /// dotnet run -- scenario5
    /// </summary>
    public class SimpleCache
    {
        // 存储结构：键 -> (值, 过期时间)
        private Dictionary<string, (object value, DateTime expireTime)> cache
            = new Dictionary<string, (object, DateTime)>();

        /// <summary>
        /// 索引器：读取缓存
        /// 自动检查是否过期，过期则删除并返回 null
        /// </summary>
        public object this[string key]
        {
            get
            {
                if (cache.ContainsKey(key))
                {
                    var (value, expireTime) = cache[key];
                    if (DateTime.Now < expireTime)
                    {
                        Console.WriteLine($"✓ 缓存命中: {key}");
                        return value;
                    }
                    else
                    {
                        cache.Remove(key);
                        Console.WriteLine($"✗ 缓存已过期且已删除: {key}");
                        return null;
                    }
                }
                Console.WriteLine($"✗ 缓存未找到: {key}");
                return null;
            }
        }

        /// <summary>设置缓存，指定有效期（秒）</summary>
        public void Set(string key, object value, int secondsToExpire)
        {
            cache[key] = (value, DateTime.Now.AddSeconds(secondsToExpire));
            Console.WriteLine($"✓ 缓存已设置: {key} (有效期 {secondsToExpire}s)");
        }

        /// <summary>获取缓存剩余有效时间（秒）</summary>
        public double GetRemainingTime(string key)
        {
            if (cache.ContainsKey(key))
            {
                var remainTime = (cache[key].expireTime - DateTime.Now).TotalSeconds;
                return remainTime > 0 ? remainTime : -1;  // -1 表示已过期
            }
            return -1;  // -1 表示不存在
        }

        /// <summary>显示缓存状态</summary>
        public void Display()
        {
            Console.WriteLine("\n【缓存状态】");
            if (cache.Count == 0)
            {
                Console.WriteLine("  缓存为空");
                return;
            }
            foreach (var item in cache)
            {
                var remainTime = (item.Value.expireTime - DateTime.Now).TotalSeconds;
                if (remainTime > 0)
                    Console.WriteLine($"  {item.Key,-20} = {item.Value.value,-20} (剩余 {remainTime:F1}s)");
                else
                    Console.WriteLine($"  {item.Key,-20} = {item.Value.value,-20} (已过期)");
            }
        }
    }

    // ============ 测试用例 ============
    class Scenario05
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║   场景 5：缓存系统（过期管理）          ║");
            Console.WriteLine("╚════════════════════════════════════════╝\n");

            SimpleCache cache = new SimpleCache();

            Console.WriteLine("【设置缓存】");
            cache.Set("token", "abc123xyz", 5);      // 5秒后过期
            cache.Set("user_id", "42", 3);           // 3秒后过期
            cache.Set("session", "sess_key_123", 10); // 10秒后过期
            cache.Set("config", "value_xyz", 2);     // 2秒后过期

            cache.Display();

            Console.WriteLine($"\n【立即读取缓存】");
            object token = cache["token"];
            object userId = cache["user_id"];
            object notExist = cache["not_exists"];

            Console.WriteLine($"\n【等待 3 秒...】");
            System.Threading.Thread.Sleep(3000);

            Console.WriteLine($"\n【再次读取缓存 - 部分过期】");
            token = cache["token"];       // 仍然有效
            userId = cache["user_id"];    // ❌ 已过期
            object config = cache["config"]; // ❌ 已过期
            object session = cache["session"]; // ✓ 仍然有效

            cache.Display();

            Console.WriteLine($"\n【查询剩余时间】");
            double remainToken = cache.GetRemainingTime("token");
            double remainSession = cache.GetRemainingTime("session");
            Console.WriteLine($"  token 剩余时间：{(remainToken > 0 ? remainToken.ToString("F1") + "s" : "已过期或不存在")}");
            Console.WriteLine($"  session 剩余时间：{(remainSession > 0 ? remainSession.ToString("F1") + "s" : "已过期或不存在")}");
        }
    }
}
