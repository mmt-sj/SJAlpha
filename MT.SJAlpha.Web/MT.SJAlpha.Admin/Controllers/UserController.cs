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
            var userList = userRepository.Queryable.Where(a => a.Type ==AccountHelper.UserStatus.Now).ToList();
            ViewData["departmentDic"] = departmentRepository.GetDepartmentDictionary();
            ViewData["zhiwuDic"] = AccountHelper.GetZhiWuDic();
            return View(userList);
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
        public IActionResult ShenHe(string type="new")
        {
            ViewData["type"] = type;
            ViewData["auditedCount"] = userRepository.Queryable.Count(a=>a.Type==AccountHelper.UserStatus.Audited);
            ViewData["newCount"] = userRepository.Queryable.Count(a=>a.Type==AccountHelper.UserStatus.New);
            var UserList = userRepository.Queryable;
            ViewData["departmentDic"] = departmentRepository.GetDepartmentDictionary();
            return View(UserList.ToList());
        }
        [HttpPost]
        public IActionResult ShenHe( int id,string type) {
            var User = userRepository.GetFirstOrDefaultById(id);
            if (User != null)
            {
                User.Type = AccountHelper.UserStatus.Audited;
                userRepository.Edit(User);
            }
            return Redirect("/User/ShenHe?type="+type);
        }
        [HttpPost]
        public IActionResult ShenHeCancel(int id, string type)
        {
            var User = userRepository.GetFirstOrDefaultById(id);
            if (User != null)
            {
                User.Type = AccountHelper.UserStatus.New;
                userRepository.Edit(User);
            }
            return Redirect("/User/ShenHe?type="+type);
        }
        public IActionResult ZhuanZheng(string type= "audited")
        {
            ViewData["type"] = type;
            ViewData["auditedCount"] = userRepository.Queryable.Count(a => a.Type == AccountHelper.UserStatus.Audited);
            ViewData["nowCount"] = userRepository.Queryable.Count(a => a.Type == AccountHelper.UserStatus.Now);
            var UserList = userRepository.Queryable;
            ViewData["departmentDic"] = departmentRepository.GetDepartmentDictionary();
            return View(UserList.ToList());
        }

        [HttpPost]
        public IActionResult ZhuanZheng(int id,string type)
        {
            var User = userRepository.GetFirstOrDefaultById(id);
            if (User != null)
            {
                User.Type = AccountHelper.UserStatus.Now;
                userRepository.Edit(User);
            }
            return Redirect("/User/ZhuanZheng?type=" + type);
        }
        [HttpPost]
        public IActionResult ZhuanZhengCancel(int id,string type) {
            var User = userRepository.GetFirstOrDefaultById(id);
            if (User != null)
            {
                User.Type = AccountHelper.UserStatus.Audited;
                userRepository.Edit(User);
            }
            return Redirect("/User/ZhuanZheng?type=" + type);
        }
    }
}