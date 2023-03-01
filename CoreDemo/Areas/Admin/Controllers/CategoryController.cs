using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController: Controller
    {
        CategoryManager _categoryManager=new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var values = _categoryManager.GetAllList().ToPagedList(page,10);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category) 
        {
            CategoryValidator validations = new CategoryValidator();
            ValidationResult result=validations.Validate(category);
            if (result.IsValid)
            {
                category.CategoryStatus = true;
                _categoryManager.Add(category);
                return RedirectToAction("Index","Category");
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
        public IActionResult DeleteCategory(int id)
        {
            var value=_categoryManager.TGetById(id);
            _categoryManager.Delete(value);
            return RedirectToAction("Index");

        }
    }
}
