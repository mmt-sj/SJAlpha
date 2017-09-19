using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MT.SJAlpha.EFCoreCodeFirst.Repository;
using MT.SJAlpha.EFCoreCodeFirst.Entitis;
using MT.SJAlpha.Web.Models;

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
                return RedirectToAction("faild", "public", new {message="您的学号已经申请过啦，如果是本人填写，静静的等待回复即可~", url1= "/Recruit", name1="重新填写申请" });//该学号已经加入过啦~
            user.CreateTime = DateTime.Now;
            user.Password = "123456";
            user.Type = "new";
            userRepository.Edit(user);
            return RedirectToAction("success","public",new {message="信息提交成功!请耐心等待答复"});
        }
    
    }
}
