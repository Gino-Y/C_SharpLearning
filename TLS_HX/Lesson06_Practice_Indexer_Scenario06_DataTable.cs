using System;
using System.Collections.Generic;
using System.Linq;

namespace TLS_HX;

/// <summary>
/// 【场景 6】数据表格类
/// 
/// 知识点：
/// - 多重索引器重载（[int, string] 和 [int] 两种参数）
/// - 泛型 Dictionary 与 List 的组合使用
/// - 表格结构的面向对象设计
/// - LINQ 查询（Keys.ToList() 等）
/// 
/// 场景描述：
/// 类似数据库表的结构，支持：
/// - [行号, 列名] 访问单个单元格
/// - [行号] 访问整行数据
/// </summary>
public class DataTable
{
    private List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

    /// <summary>
    /// 索引器 1：[行号, 列名] 访问/修改单个单元格
    /// </summary>
    public object this[int rowIndex, string columnName]
    {
        get
        {
            if (rowIndex >= 0 && rowIndex < rows.Count)
                return rows[rowIndex].ContainsKey(columnName) ? rows[rowIndex][columnName] : null;
            return null;
        }
        set
        {
            if (rowIndex >= 0 && rowIndex < rows.Count)
            {
                rows[rowIndex][columnName] = value;
                Console.WriteLine($"✓ 行 {rowIndex}, 列 '{columnName}' 已更新为 {value}");
            }
        }
    }

    /// <summary>
    /// 索引器 2：[行号] 访问整行数据
    /// </summary>
    public Dictionary<string, object> this[int rowIndex]
    {
        get
        {
            return rowIndex >= 0 && rowIndex < rows.Count ? rows[rowIndex] : null;
        }
    }

    /// <summary>添加一行数据</summary>
    public void AddRow(Dictionary<string, object> row)
    {
        rows.Add(new Dictionary<string, object>(row));
        Console.WriteLine($"✓ 新增行，共 {rows.Count} 行数据");
    }

    /// <summary>获取行数</summary>
    public int RowCount => rows.Count;

    /// <summary>显示表格</summary>
    public void Display()
    {
        if (rows.Count == 0)
        {
            Console.WriteLine("\n【表格为空】");
            return;
        }

        Console.WriteLine("\n【数据表格】");
        var columns = rows[0].Keys.ToList();

        // 显示表头
        foreach (var col in columns)
            Console.Write($"{col,-15} ");
        Console.WriteLine();
        Console.WriteLine(new string('-', columns.Count * 16));

        // 显示数据行
        for (int i = 0; i < rows.Count; i++)
        {
            Console.Write($"[{i}] ");
            foreach (var col in columns)
                Console.Write($"{(rows[i][col] ?? "NULL"),-15} ");
            Console.WriteLine();
        }
    }
}

// ============ 测试用例 ============
public class Scenario06
{
    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║   场景 6：数据表格类                    ║");
        Console.WriteLine("╚════════════════════════════════════════╝\n");

        DataTable table = new DataTable();

        Console.WriteLine("【添加数据行】");
        table.AddRow(new Dictionary<string, object>
        {
            { "ID", 1 }, { "姓名", "张三" }, { "年龄", 25 }, { "部门", "研发部" }
        });
        table.AddRow(new Dictionary<string, object>
        {
            { "ID", 2 }, { "姓名", "李四" }, { "年龄", 30 }, { "部门", "销售部" }
        });
        table.AddRow(new Dictionary<string, object>
        {
            { "ID", 3 }, { "姓名", "王五" }, { "年龄", 28 }, { "部门", "研发部" }
        });
        table.AddRow(new Dictionary<string, object>
        {
            { "ID", 4 }, { "姓名", "赵六" }, { "年龄", 35 }, { "部门", "市场部" }
        });

        table.Display();

        Console.WriteLine($"\n【查询单个单元格】");
        Console.WriteLine($"  第 0 行，姓名：{table[0, "姓名"]}");
        Console.WriteLine($"  第 2 行，部门：{table[2, "部门"]}");
        Console.WriteLine($"  第 1 行，年龄：{table[1, "年龄"]}");

        Console.WriteLine($"\n【查询整行数据】");
        var row2 = table[2];
        Console.WriteLine($"  第 2 行数据：ID={row2["ID"]}, 姓名={row2["姓名"]}, 年龄={row2["年龄"]}, 部门={row2["部门"]}");

        Console.WriteLine($"\n【修改数据】");
        Console.WriteLine($"修改前：第 1 行，姓名 = {table[1, "姓名"]}, 年龄 = {table[1, "年龄"]}");
        table[1, "姓名"] = "李四（李总）";
        table[1, "年龄"] = 31;
        table[1, "部门"] = "销售总部";

        table.Display();

        Console.WriteLine($"\n【统计信息】");
        Console.WriteLine($"  共有 {table.RowCount} 行员工");
    }
}
