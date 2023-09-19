﻿using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyeLearningProject.Controllers
{
    public class AdminCourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IGenericService<Category> _categoryService;
        private readonly IGenericService<Instructor> _instructorService;

        public AdminCourseController(ICourseService courseService, IGenericService<Category> categoryService, IGenericService<Instructor> instructorService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _instructorService = instructorService;
        }

        public IActionResult Index()
        {
           var values= _courseService.GetAll();
            return View(values);
        }

        public IActionResult DeleteCourse(int id)
        {
            _courseService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCourse(int id)
        {
            var cat = _categoryService.GetList();
            var inst = _instructorService.GetList();
            List<SelectListItem> category = (from x in cat
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();

            ViewBag.category = category;
            List<SelectListItem> instructor = (from x in inst
                                               select new SelectListItem
                                               {
                                                   Text = x.Name + " " + x.Surname,
                                                   Value = x.InstructorId.ToString()
                                               }).ToList();
            ViewBag.instructor = instructor;
            var values = _courseService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditCourse(Course course)
        {
            _courseService.Update(course);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddCourse()
        {
            var cat= _categoryService.GetList();
            var inst = _instructorService.GetList();
            List<SelectListItem> category = (from x in cat
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();

            ViewBag.category=category;
            List<SelectListItem> instructor = (from x in inst
                                             select new SelectListItem
                                             {
                                                 Text = x.Name + " " + x.Surname,
                                                 Value = x.InstructorId.ToString()
                                             }).ToList();
            ViewBag.instructor=instructor;
            return View();
        }
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            course.Status = true;
            _courseService.Insert(course);
            return RedirectToAction("Index");
        }
    }
}
