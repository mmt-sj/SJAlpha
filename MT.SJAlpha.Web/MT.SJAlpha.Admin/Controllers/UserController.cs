using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MT.SJAlpha.EFCoreCodeFirst.Repository;
using MT.SJAlpha.Admin.Common;

namespace MT.SJAlpha.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository userRepository = new UserRepository();
        private readonly DepartmentRepository departmentRepository = new DepartmentRepository();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Recruit()
        {
            var newUserList = userRepository.Queryable.Where(a => a.Type == "new").ToList();
            ViewData["departmentDic"] = departmentRepository.GetDepartmentDictionary();
            return View(newUserList);
        }
        public IActionResult Navigation()
        {
            return View();
        }
        public IActionResult ShenHe()
        {
            ViewData["auditedCount"] = userRepository.Queryable.Count(a=>a.Type==AccountHelper.UserStatus.Audited);
            ViewData["newCount"] = userRepository.Queryable.Count(a=>a.Type==AccountHelper.UserStatus.New);
            var UserList = userRepository.Queryable;
            ViewData["departmentDic"] = departmentRepository.GetDepartmentDictionary();
            return View(UserList.ToList());
        }
        [HttpPost]
        public IActionResult ShenHe( int id) {
            var User = userRepository.GetFirstOrDefaultById(id);
            if (User != null)
            {
                User.Type = AccountHelper.UserStatus.Audited;
                userRepository.Edit(User);
            }
            return Redirect("/User/ShenHe");
        }
    }
}