using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
    
    public class BlogController: Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        Context context = new Context();
        [AllowAnonymous]
        public IActionResult Index()
        {
            var result=blogManager.GetBlogListWithCategory();
            return View(result);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.Id = id;
            var values=blogManager.GetListBlogById(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var userName = User.Identity.Name;
            var userEmail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var writerId=context.Writers.Where(x=>x.WriterEmail==userEmail).Select(y=>y.WriterId).FirstOrDefault();
            var values = blogManager.GetListWithCategoryByWriter(writerId);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            
            List<SelectListItem> categories = (from x in categoryManager.GetAllList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value=x.CategoryId.ToString()
                                               }).ToList() ;
            ViewBag.categoriesResult=categories;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator blogValidator=new BlogValidator();
            ValidationResult result=blogValidator.Validate(blog);
            var userName = User.Identity.Name;
            var userEmail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterEmail == userEmail).Select(y => y.WriterId).FirstOrDefault();
            if (result.IsValid)
            {
                //False yapılarak admine onaylatmak için kod yazılabilir.
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = writerId;
                blogManager.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult BlogDelete(int id)
        {
            var blogValue= blogManager.TGetById(id);
            blogManager.Delete(blogValue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult BlogEdit(int id)
        {
            var blogValue=blogManager.TGetById(id);
            List<SelectListItem> categories = (from x in categoryManager.GetAllList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categoriesResult = categories;
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult BlogEdit(Blog blog)
        {
            var userName = User.Identity.Name;
            var userEmail = context.Users.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterEmail == userEmail).Select(y => y.WriterId).FirstOrDefault();
            blog.WriterId = writerId;
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            blogManager.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
