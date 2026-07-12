using System;
using System.Collections.Generic;
using System.Linq;

namespace TLS_HX.Lesson06_Indexer_Practice
{
    /// <summary>
    /// 【场景 7】权限管理系统
    /// 
    /// 知识点：
    /// - bool 返回类型的索引器
    /// - 多参数索引器用于权限检查
    /// - 权限模型的实现
    /// - 列表操作（Add、Remove、Contains）
    /// 
    /// 场景描述：
    /// 权限管理系统，支持：
    /// - [用户, 权限] 检查是否有某权限（返回 bool）
    /// - [用户] 获取用户的所有权限（返回 List）
    /// 
    /// 运行方式：
    /// dotnet run -- scenario7
    /// </summary>
    public class PermissionManager
    {
        private Dictionary<string, List<string>> userPermissions
            = new Dictionary<string, List<string>>();

        /// <summary>
        /// 索引器 1：[用户名, 权限名] 检查是否拥有权限
        /// 返回 bool，true 表示有权限
        /// </summary>
        public bool this[string userName, string permission]
        {
            get
            {
                bool hasPermission = userPermissions.ContainsKey(userName) &&
                                     userPermissions[userName].Contains(permission);
                return hasPermission;
            }
        }

        /// <summary>
        /// 索引器 2：[用户名] 获取用户的所有权限
        /// </summary>
        public List<string> this[string userName]
        {
            get
            {
                return userPermissions.ContainsKey(userName) ?
                       userPermissions[userName] : new List<string>();
            }
        }

        /// <summary>授予用户权限</summary>
        public void GrantPermission(string userName, string permission)
        {
            if (!userPermissions.ContainsKey(userName))
                userPermissions[userName] = new List<string>();

            if (!userPermissions[userName].Contains(permission))
            {
                userPermissions[userName].Add(permission);
                Console.WriteLine($"✓ 已授予 {userName} 权限: {permission}");
            }
            else
                Console.WriteLine($"⚠ {userName} 已有权限: {permission}");
        }

        /// <summary>撤销用户权限</summary>
        public void RevokePermission(string userName, string permission)
        {
            if (userPermissions.ContainsKey(userName) &&
                userPermissions[userName].Remove(permission))
            {
                Console.WriteLine($"✓ 已撤销 {userName} 权限: {permission}");
            }
            else
                Console.WriteLine($"✗ {userName} 不存在该权限");
        }

        /// <summary>获取用户权限数量</summary>
        public int GetPermissionCount(string userName)
        {
            return userPermissions.ContainsKey(userName) ? userPermissions[userName].Count : 0;
        }

        /// <summary>显示权限管理表</summary>
        public void Display()
        {
            Console.WriteLine("\n【权限管理表】");
            if (userPermissions.Count == 0)
            {
                Console.WriteLine("  无任何用户");
                return;
            }
            foreach (var user in userPermissions)
            {
                Console.WriteLine($"  {user.Key}:");
                if (user.Value.Count == 0)
                    Console.WriteLine("    (无权限)");
                else
                    foreach (var perm in user.Value)
                        Console.WriteLine($"    ✓ {perm}");
            }
        }
    }

    // ============ 测试用例 ============
    class Scenario07
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║   场景 7：权限管理系统                  ║");
            Console.WriteLine("╚════════════════════════════════════════╝\n");

            PermissionManager pm = new PermissionManager();

            Console.WriteLine("【授予权限】");
            pm.GrantPermission("admin", "delete_user");
            pm.GrantPermission("admin", "edit_config");
            pm.GrantPermission("admin", "view_logs");
            pm.GrantPermission("admin", "manage_permission");

            pm.GrantPermission("user", "view_profile");
            pm.GrantPermission("user", "edit_profile");
            pm.GrantPermission("user", "view_posts");

            pm.GrantPermission("guest", "view_posts");

            pm.Display();

            Console.WriteLine($"\n【权限检查 - 使用索引器 [用户, 权限]】");
            bool can1 = pm["admin", "delete_user"];
            Console.WriteLine($"  admin 有 delete_user 权限？ {(can1 ? "✓" : "✗")}");

            bool can2 = pm["user", "delete_user"];
            Console.WriteLine($"  user 有 delete_user 权限？ {(can2 ? "✓" : "✗")}");

            bool can3 = pm["user", "view_profile"];
            Console.WriteLine($"  user 有 view_profile 权限？ {(can3 ? "✓" : "✗")}");

            bool can4 = pm["guest", "edit_config"];
            Console.WriteLine($"  guest 有 edit_config 权限？ {(can4 ? "✓" : "✗")}");

            Console.WriteLine($"\n【权限统计 - 使用索引器 [用户]】");
            Console.WriteLine($"  admin 权限数：{pm.GetPermissionCount("admin")}");
            Console.WriteLine($"  user 权限数：{pm.GetPermissionCount("user")}");
            Console.WriteLine($"  guest 权限数：{pm.GetPermissionCount("guest")}");

            Console.WriteLine($"\n【获取用户权限列表】");
            var adminPerms = pm["admin"];
            Console.WriteLine($"  admin 拥有权限：{string.Join(", ", adminPerms)}");

            var userPerms = pm["user"];
            Console.WriteLine($"  user 拥有权限：{string.Join(", ", userPerms)}");

            Console.WriteLine($"\n【撤销权限】");
            pm.RevokePermission("admin", "delete_user");
            pm.RevokePermission("user", "edit_profile");

            Console.WriteLine($"\n【撤销后的权限检查】");
            bool can5 = pm["admin", "delete_user"];
            Console.WriteLine($"  admin 有 delete_user 权限？ {(can5 ? "✓" : "✗")}");

            bool can6 = pm["user", "edit_profile"];
            Console.WriteLine($"  user 有 edit_profile 权限？ {(can6 ? "✓" : "✗")}");

            pm.Display();
        }
    }
}
