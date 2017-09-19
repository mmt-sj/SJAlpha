using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MT.SJAlpha.EFCoreCodeFirst.Repository;

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
    }
}