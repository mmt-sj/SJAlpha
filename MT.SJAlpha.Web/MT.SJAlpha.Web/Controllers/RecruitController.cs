using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MT.SJAlpha.EFCoreCodeFirst.Repository;
using MT.SJAlpha.EFCoreCodeFirst.Entitis;
namespace MT.SJAlpha.Web.Controllers
{
    public class RecruitController : Controller
    {
        private readonly DepartmentRepository departmentRepository = new DepartmentRepository();
        private readonly UserRepository userRepository = new UserRepository();
        public IActionResult Index()
        {
            var departmentDic = departmentRepository.GetDepartmentDictionary();
            ViewData["departmentDic"] = departmentDic;
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            var first = userRepository.GetFirstOrDefaultByAccount(user.Account);
            if (first != null)
                return RedirectToAction("faild","public", new { message = "该学号已经加入过啦" });//该学号已经加入过啦~
            user.CreateTime = DateTime.Now;
            user.Password = "123456";
            user.Type = "new";
            userRepository.Edit(user);
            return RedirectToAction("success","public",new {message="信息提交成功!请耐心等待答复"});
        }
    }
}
