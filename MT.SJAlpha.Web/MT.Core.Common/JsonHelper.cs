
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
namespace MT.Core.Common
{
    public class JsonHelper
    {
        public static string Success(object obj, string message = "请求成功")
        {
            var json = new { status = 1, message = message, data = obj };
            var str = JsonConvert.SerializeObject(json);
            return str;
        }
        public static string Error(string message = "请求失败")
        {
            var json = new { status = 1, message = message };
            var str = JsonConvert.SerializeObject(json);
            return str;
        }
    }
}
