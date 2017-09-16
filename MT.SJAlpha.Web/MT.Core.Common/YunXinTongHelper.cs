using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;
namespace MT.Core.Common
{
    public class YunXinTongHelper
    {
        private string _accessKeyId,_accessSecret;
        public YunXinTongHelper(string accessKeyId,string accessSecret)
        {
            _accessKeyId = accessKeyId;
            _accessKeyId = accessSecret;
        }
        public void AccessToken()
        {
            var dt = DateTime.Now.ToString("r");//GMT时区
            var paraDic = new SortedList<string, string>();
            //系统参数
            paraDic.Add("SignatureMethod", "HMAC-SHA1");
            paraDic.Add("SignatureNonce", Guid.NewGuid().ToString());
            paraDic.Add("AccessKeyId",_accessKeyId);
            paraDic.Add("SignatureVersion", "1.0");
            paraDic.Add("Timestamp",dt);
            paraDic.Add("Format", "XML");
            //业务API参数
            paraDic.Add("Action", "SendSms");
            paraDic.Add("Version", "2017-05-25");
            paraDic.Add("RegionId", "cn-hangzhou");
            paraDic.Add("PhoneNumbers", "15300000001");
            paraDic.Add("SignName", "阿里云短信测试专用");
            paraDic.Add("TemplateParam", "{\"customer\":\"test\"}");
            paraDic.Add("TemplateCode", "SMS_71390007");
            paraDic.Add("OutId", "123");
            //去除签名关键字Key
            if (paraDic.ContainsKey("Signature"))
                paraDic.Remove("Signature");
            //顺序排序
            //构造待签名的字符串
            StringBuilder sortQueryStringTmp = new StringBuilder();
            foreach (var item in paraDic) {
                sortQueryStringTmp.Append("&").Append(specialUrlEncode(item.Key)).Append("=").Append(specialUrlEncode(item.Value));
            }
            // 去除第一个多余的&符号
            string sortedQueryString = sortQueryStringTmp.Remove(0,1).ToString();
            StringBuilder stringToSign = new StringBuilder();
            stringToSign.Append("GET").Append("&");
            stringToSign.Append(specialUrlEncode("/")).Append("&");
            stringToSign.Append(specialUrlEncode(sortedQueryString));

        //    string sign = sign(accessSecret + "&", stringToSign.toString());
        }
        /// <summary>
        /// 特殊URL编码处理 即在一般的URLEncode后再增加三种字符替换：加号（+）替换成 %20、星号（*）替换成 %2A、%7E 替换回波浪号（~）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string specialUrlEncode(string value) {
             return HttpUtility.UrlEncode(value, Encoding.UTF8).Replace("+", "%20").Replace("*","%2A").Replace("%7E","~") ;
        }
        /// <summary>
        /// 签名采用HmacSHA1算法 + Base64，编码采用：UTF-8参考代码如下：
        /// </summary>
        /// <param name="accessSecret"></param>
        /// <param name="stringToSign"></param>
        /// <returns></returns>
        public static string sign(string accessSecret,string stringToSign)
        {
            HMACSHA1 sha1 = new HMACSHA1(Encoding.UTF8.GetBytes(accessSecret));
            //Encoding.UTF8.GetBytes(stringToSign)
            byte[] data = null;
            var result = sha1.ComputeHash(data);
            return Convert.ToBase64String(result);
        }
    }
}
