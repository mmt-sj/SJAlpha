using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MT.SJAlpha.Admin.Common
{
    public class AccountHelper
    {
        public static string GetNianJiForAccount(string account) {
            if (account.Length == 11) {
                return account.Substring(3,2);
            }
            else { return "未知"; }  
        }
    }
}
