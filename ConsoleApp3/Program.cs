using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<權限> list = new List<權限>
            {權限.修改,權限.匯出,權限.刪除 };

            var permission = (權限)list.Sum(x => (int)x);
            Console.WriteLine(permission);

            查詢某個權限是否存在(permission, 權限.查詢);
            新增權限(ref permission, 權限.權限全開);
            查詢某個權限是否存在(permission, 權限.查詢);
            Console.WriteLine();
            移除某個權限(ref permission, 權限.修改);
            查詢某個權限是否存在(permission, 權限.修改);
            Parse某個字串變成enum("檢視,查詢", ref permission);

            list = permission.ToString().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => (權限)Enum.Parse(typeof(權限), x)).ToList();

            Console.ReadKey();
        }

        static void 新增權限(ref 權限 permission, 權限 newPermission)
        {
            permission |= newPermission;
        }


        static void 查詢某個權限是否存在(權限 permission, 權限 queryPermission)
        {
            Console.Write($"是否有{queryPermission}權限？");
            Console.WriteLine((permission & queryPermission) == queryPermission ? "有" : "沒有");
            Console.WriteLine($"目前的數字{(int)permission}");
        }

        static void Parse某個字串變成enum(string queryPermission, ref 權限 permission)
        {
            Console.Write($"是否有{queryPermission}權限？");
            Console.WriteLine(Enum.TryParse(queryPermission, out permission) ? "有" : "沒有");
            Console.WriteLine($"目前的數字{(int)permission}");
        }

        static void 移除某個權限(ref 權限 permission, 權限 removedPermission)
        {
            Console.WriteLine($"目前的全部權限:{permission}");
            permission &= ~removedPermission;
            Console.WriteLine($"移除後的全部權限:{permission}");
        }
    }
    [Flags]
    public enum 權限
    {
        無權限,
        檢視 = 1,
        查詢 = 2,
        修改 = 4,
        刪除 = 8,
        匯出 = 16,
        權限全開 = 無權限 | 檢視 | 查詢 | 修改 | 刪除 | 匯出
    }
}
