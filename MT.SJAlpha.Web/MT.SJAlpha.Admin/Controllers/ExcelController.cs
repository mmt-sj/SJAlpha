using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using MT.SJAlpha.EFCoreCodeFirst.Repository;
using MT.SJAlpha.Admin.Extends;
using System.IO;
using Microsoft.AspNetCore.Http;
using MT.SJAlpha.Admin.Common;

namespace MT.SJAlpha.Admin.Controllers
{
    public class ExcelController : Controller
    {
        private readonly UserRepository userRepository = new UserRepository();
        private readonly DepartmentRepository departmentRepository = new DepartmentRepository();
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult GetApplyAccountInfoExcel(string type)
        {
            HSSFWorkbook wk = new HSSFWorkbook();//创建工作簿
            ISheet sheet = wk.CreateSheet("sheet1");//创建一个sheet                     
            IRow row = sheet.CreateRow(0); //在第一行创建行  
            ICell cell = row.CreateCell(0);  //在第一行的第一列创建单元格 
            cell.SetCellValue("学号");
            row.CreateCell(1).SetCellValue("姓名");
            row.CreateCell(2).SetCellValue("性别");
            row.CreateCell(3).SetCellValue("院系");
            row.CreateCell(4).SetCellValue("年级");
            row.CreateCell(5).SetCellValue("电话");
            row.CreateCell(6).SetCellValue("申请时间");
            row.CreateCell(7).SetCellValue("申请理由");
            row.CreateCell(8).SetCellValue("备注");
            row.CreateCell(9).SetCellValue("状态");
            var userList = userRepository.GetAccountForType(type).ToList();
            var departmentList = departmentRepository.GetDepartmentDictionary();
            for (var i= 0;i < userList.Count;i++) {
                IRow rowTemp = sheet.CreateRow(i + 1);
                rowTemp.CreateCell(0).SetCellValue(userList[i].Account);
                rowTemp.CreateCell(1).SetCellValue(userList[i].Name);
                rowTemp.CreateCell(2).SetCellValue(userList[i].Sex);
                rowTemp.CreateCell(3).SetCellValue(departmentList.GetValueOrDefault(userList[i].DepartmentId));
                rowTemp.CreateCell(4).SetCellValue(Common.AccountHelper.GetNianJiForAccount(userList[i].Account));
                rowTemp.CreateCell(5).SetCellValue(userList[i].PhoneNumber);
                rowTemp.CreateCell(6).SetCellValue(userList[i].CreateTime.ToFullChineseTime());
                rowTemp.CreateCell(7).SetCellValue(userList[i].Remark);
                rowTemp.CreateCell(8).SetCellValue("");
                var typeStr = AccountHelper.GetUserStatusDic().FirstOrDefault(a => a.Key == userList[i].Type).Value;
                rowTemp.CreateCell(9).SetCellValue(typeStr);
            }
            // 写入到客户端  
            MemoryStream ms = new System.IO.MemoryStream();
            wk.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            wk = null;
            return File(ms, "application/x-xls", string.Format("招新_{0}.xls", DateTime.Now.ToFileTime()));
        }
    }
}