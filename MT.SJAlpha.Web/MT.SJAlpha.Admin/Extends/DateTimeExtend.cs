using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MT.SJAlpha.Admin.Extends
{
    public static class DateTimeExtend
    {
        public static string ToFullChineseTime (this DateTime time)
        {
            return time.ToString("yyyy年MM月dd日 HH时mm分");
        }
    }
}
