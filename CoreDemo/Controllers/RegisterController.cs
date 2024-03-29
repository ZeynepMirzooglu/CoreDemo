﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class RegisterController: Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Index(Writer writer)
		{
            WriterValidator validationRules=new WriterValidator();
            ValidationResult validationResult=validationRules.Validate(writer);
            if(validationResult.IsValid) 
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "Deneme Test";
                writerManager.Add(writer);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
		}
	}
}
