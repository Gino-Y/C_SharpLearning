using System;
using System.Collections.Generic;
using System.Linq;

namespace TLS_HX;

/// <summary>
/// 【场景 2】游戏背包系统
/// 
/// 知识点：
/// - 字典（Dictionary）的 ContainsKey、Add、Remove 操作
/// - 索引器的 set 中编写复杂逻辑（自动合并、删除）
/// - 库存管理的实现思路
/// 
/// 场景描述：
/// 游戏中的背包系统，玩家通过物品名称直接访问数量
/// 设置数量时自动处理：添加、更新、删除操作
/// </summary>
public class GameBackpack
{
    private Dictionary<string, int> items = new Dictionary<string, int>();

    /// <summary>
    /// 索引器：通过物品名访问数量
    /// get：不存在返回 0
    /// set：值 <= 0 时删除；存在时更新；不存在时添加
    /// </summary>
    public int this[string itemName]
    {
        get
        {
            return items.ContainsKey(itemName) ? items[itemName] : 0;
        }
        set
        {
            if (value <= 0)
            {
                if (items.ContainsKey(itemName))
                {
                    items.Remove(itemName);
                    Console.WriteLine($"✓ {itemName} 已从背包移除");
                }
            }
            else if (items.ContainsKey(itemName))
            {
                items[itemName] = value;
                Console.WriteLine($"✓ {itemName} 数量更新为 {value}");
            }
            else
            {
                items.Add(itemName, value);
                Console.WriteLine($"✓ {itemName} x{value} 已加入背包");
            }
        }
    }

    /// <summary>显示背包内容</summary>
    public void Display()
    {
        Console.WriteLine("\n【背包内容】");
        if (items.Count == 0)
        {
            Console.WriteLine("  背包为空");
            return;
        }
        int index = 1;
        foreach (var item in items)
        {
            Console.WriteLine($"  {index}. {item.Key,-15} x {item.Value,3}");
            index++;
        }
    }

    /// <summary>背包中物品总数</summary>
    public int GetTotalItems() => items.Values.Sum();

    /// <summary>背包中物品种类数</summary>
    public int GetItemCount() => items.Count;
}

// ============ 测试用例 ============
public class Scenario02
{
    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║   场景 2：游戏背包系统                  ║");
        Console.WriteLine("╚════════════════════════════════════════╝\n");

        GameBackpack bag = new GameBackpack();

        Console.WriteLine("【初始背包】");
        bag["金币"] = 100;
        bag["魔法药水"] = 5;
        bag["长剑"] = 1;
        bag["盾牌"] = 1;

        bag.Display();
        Console.WriteLine($"总计：{bag.GetTotalItems()} 件物品，{bag.GetItemCount()} 种类");

        Console.WriteLine($"\n【捡到新物品】");
        bag["金币"] = 250;  // 合并金币
        bag["魔法书"] = 1;

        bag.Display();
        Console.WriteLine($"总计：{bag.GetTotalItems()} 件物品，{bag.GetItemCount()} 种类");

        Console.WriteLine($"\n【使用物品】");
        bag["魔法药水"] -= 2;
        bag["魔法药水"] = 0;  // 用完了
        bag["金币"] = 200;

        bag.Display();
        Console.WriteLine($"总计：{bag.GetTotalItems()} 件物品，{bag.GetItemCount()} 种类");

        Console.WriteLine($"\n【查询物品数量】");
        Console.WriteLine($"  金币数量：{bag["金币"]}");
        Console.WriteLine($"  弓箭数量：{bag["弓箭"]}（不存在）");
    }
}
