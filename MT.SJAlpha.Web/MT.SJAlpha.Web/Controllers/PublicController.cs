using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MT.SJAlpha.Web.Controllers
{
    public class PublicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Success(string message="操作成功！",string url="")
        {
            ViewData["message"] = message;
            ViewData["url"] = url;
            return View();
        }
        public IActionResult Faild(string message="操作失败", string url = "")
        {
            ViewData["message"] = message;
            ViewData["url"] = url;
            return View();
        }
    }
}