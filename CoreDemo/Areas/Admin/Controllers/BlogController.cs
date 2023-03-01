using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController: Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workBook=new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1,1).Value = "Blog Id";
                workSheet.Cell(1, 2).Value = "Blog Adı";
                //İlk satırda BlogId ve Blog Adı yazacağı için 2nci satırdan başlamak için blogRowCount 2den başlatıldı.
                int blogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.Id;
                    workSheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }
                using (var stream=new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Deneme.xlsx");
                }
            }
           
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModel = new List<BlogModel>
            {
                new BlogModel{Id=1,BlogName="C# Programlamaya Giriş"},
                new BlogModel{Id=2,BlogName="Tesla Firmasının Araçları" },
                new BlogModel{Id=3,BlogName="2023 Olimpiyat Oyunları" },
            };
            return blogModel;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog Id";
                workSheet.Cell(1, 2).Value = "Blog Adı";
                //İlk satırda BlogId ve Blog Adı yazacağı için 2nci satırdan başlamak için blogRowCount 2den başlatıldı.
                int blogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.Id;
                    workSheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Deneme.xlsx");
                }
            }
        }
        public List<BlogModelDynamic> BlogTitleList()
        {
            List<BlogModelDynamic> blogModels= new List<BlogModelDynamic>();
            using (var context=new Context())
            {
                blogModels=context.Blogs.Select(x=>new BlogModelDynamic
                {
                    Id=x.BlogId,
                    BlogName=x.BlogTitle

                }).ToList();
            }
            return blogModels;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
