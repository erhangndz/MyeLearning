﻿using Business.Interfaces;
using Entity.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.Default
{
    public class _IndexCourses:ViewComponent
    {
        private readonly ICourseService _courseService;
        private readonly IGenericService<Review> _reviewService;

		public _IndexCourses(ICourseService courseService, IGenericService<Review> reviewService)
		{
			_courseService = courseService;
			_reviewService = reviewService;
		}

		public IViewComponentResult Invoke()
        {
            ViewBag.course2AvgScore = _reviewService.GetList().Where(x => x.CourseId == 2).Average(x => x.Score).ToString("0.#");
            ViewBag.course3AvgScore = _reviewService.GetList().Where(x => x.CourseId == 3).Average(x => x.Score).ToString("0.#");
            ViewBag.course4AvgScore = _reviewService.GetList().Where(x => x.CourseId == 4).Average(x => x.Score).ToString("0.#");
            ViewBag.course8AvgScore = _reviewService.GetList().Where(x => x.CourseId == 8).Average(x => x.Score).ToString("0.#");
            var values = _courseService.GetAll().TakeLast(6).ToList();
            return View(values);
        }
    }
}
