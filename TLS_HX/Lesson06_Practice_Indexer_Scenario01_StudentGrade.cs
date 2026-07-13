using System;
using System.Collections.Generic;
using System.Linq;

namespace TLS_HX;

/// <summary>
/// 【场景 1】学生成绩管理系统
/// 
/// 知识点：
/// - 字符串（string）作为索引器参数
/// - 索引器中进行数据验证
/// - 字典（Dictionary）的基本操作
/// 
/// 场景描述：
/// 通过科目名称作为"索引"，直接访问和修改学生某科成绩
/// 支持自动验证成绩范围（0-100）
/// </summary>
public class StudentGradeManager
{
    private Dictionary<string, double> scores = new Dictionary<string, double>();

    /// <summary>
    /// 索引器：通过科目名称（string）访问成绩
    /// get：若科目不存在返回 0
    /// set：验证成绩范围 0-100，无效输入拒绝修改
    /// </summary>
    public double this[string subject]
    {
        get
        {
            return scores.ContainsKey(subject) ? scores[subject] : 0;
        }
        set
        {
            if (value >= 0 && value <= 100)
            {
                scores[subject] = value;
                Console.WriteLine($"✓ {subject} 成绩已设置为 {value}");
            }
            else
            {
                Console.WriteLine($"✗ 错误：成绩必须在 0-100 之间！");
            }
        }
    }

    /// <summary>显示所有成绩</summary>
    public void Display()
    {
        Console.WriteLine("\n【学生成绩表】");
        if (scores.Count == 0)
        {
            Console.WriteLine("  暂无成绩记录");
            return;
        }
        foreach (var score in scores)
        {
            Console.WriteLine($"  {score.Key,-10}: {score.Value,6:F1} 分");
        }
    }

    /// <summary>计算平均分</summary>
    public double GetAverage() => scores.Count > 0 ? scores.Values.Average() : 0;

    /// <summary>统计及格数量</summary>
    public int GetPassCount() => scores.Count(x => x.Value >= 60);
}

// ============ 测试用例 ============
public class Scenario01
{
    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║   场景 1：学生成绩管理系统              ║");
        Console.WriteLine("╚════════════════════════════════════════╝\n");

        StudentGradeManager student = new StudentGradeManager();

        Console.WriteLine("【设置成绩】");
        student["数学"] = 95;
        student["英语"] = 88;
        student["语文"] = 92;
        student["物理"] = 105;  // ❌ 会被拒绝
        student["化学"] = 87;
        student["生物"] = -5;   // ❌ 会被拒绝

        student.Display();

        Console.WriteLine($"\n【统计信息】");
        Console.WriteLine($"  平均分：{student.GetAverage():F2}");
        Console.WriteLine($"  及格科目：{student.GetPassCount()} 门");

        Console.WriteLine($"\n【查询具体成绩】");
        Console.WriteLine($"  数学成绩：{student["数学"]}");
        Console.WriteLine($"  计算机成绩（不存在）：{student["计算机"]}");

        Console.WriteLine($"\n【修改成绩】");
        student["数学"] = 98;
        student.Display();
    }
}
