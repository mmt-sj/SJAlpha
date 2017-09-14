using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace MT.SJAlpha.Admin.Controllers
{
    public class ExcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private void GetNewAccountInfo()
        {
            HSSFWorkbook wk = new HSSFWorkbook();//创建工作簿
            ISheet sheet = wk.CreateSheet("sheet1");//创建一个sheet                     
            IRow row = sheet.CreateRow(0); //在第一行创建行  
            ICell cell = row.CreateCell(0);  //在第一行的第一列创建单元格 
            cell.SetCellValue("学号"); 
        }
    }
}