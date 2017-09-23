using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MT.SJAlpha.Admin.Common
{

    public class AccountHelper
    {
        public struct UserPosition
        {
            /// <summary>
            /// 部长
            /// </summary>
            public static string BuZhang { get { return "buzhang"; } }
            /// <summary>
            /// 副部长
            /// </summary>
            public static string FuBuZhang { get { return "fubuzhang"; } }
            /// <summary>
            /// 秘书
            /// </summary>
            public static string MiShu { get { return "mishu"; } }
            /// <summary>
            /// 副秘书
            /// </summary>
            public string FuMiShu { get { return "fumishu"; } }
            /// <summary>
            /// 组长
            /// </summary>
            public static string ZuZhang { get { return "zuzhang"; } }
            /// <summary>
            /// 组员
            /// </summary>
            public static string ZuYuan { get { return "zuyuan"; } }
        }
        public struct UserStatus
        {
            /// <summary>
            /// 申请加入
            /// </summary>
            public static string New { get { return "new"; } }
            /// <summary>
            /// 审核通过
            /// </summary>
            public static string Audited { get { return "audited"; } }
            /// <summary>
            /// 审核未通过
            /// </summary>
            public static string AuditFailed { get { return "audited_failed"; } }
            /// <summary>
            /// 退休成员
            /// </summary>
            public static string Old { get { return "old"; } }
            /// <summary>
            /// 现在成员
            /// </summary>
            public static string Now { get { return "now"; } }
            /// <summary>
            /// 移除成员
            /// </summary>
            public static string Delete { get { return "delete"; } }
        }
       
        public static string GetNianJiForAccount(string account)
        {
            if (account.Length == 11)
            {
                return account.Substring(3, 2);
            }
            else { return "未知"; }
        }

        public static Dictionary<string, string> GetZhiWuDic()
        {
            return new Dictionary<string, string>() {
                 {"buzhang","部长" }, { "fubuzhang","副部长"},{ "mishu","秘书"}, { "fumishu","副秘书"},{ "zuzhang","组长"},{ "zuyuan","组员"},{"","新人" }
            };
        }
        public static Dictionary<string, string> GetUserStatusDic()
        {
            return new Dictionary<string, string>() {
                 {"now","在职" }, { "old","毕业"}
            };
        }
    }
}
