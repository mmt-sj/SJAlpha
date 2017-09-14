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
        public IActionResult Success(string message="",string url1="",string url2="")
        {
            ViewData["message"] = message;
            ViewData["url1"] = url1;
            ViewData["url2"] = url2;
            return View();
        }
        public IActionResult Faild(string message="", string url1 = "",string url2="")
        {
            ViewData["message"] = message;
            ViewData["url1"] = url1;
            ViewData["url2"] = url2;
            return View();
        }
    }
}