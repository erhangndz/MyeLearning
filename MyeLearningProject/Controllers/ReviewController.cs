﻿using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyeLearningProject.Controllers
{
    [Authorize(Roles = "Student")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly ICourseService _courseService;
        private readonly UserManager<AppUser> _userManager;

        public ReviewController(IReviewService reviewService, ICourseService courseService, UserManager<AppUser> userManager)
        {
            _reviewService = reviewService;
            _courseService = courseService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var course = _courseService.GetList();
            List<SelectListItem> courseList = (from x in course
                                               select new SelectListItem
                                               {
                                                   Text = x.CourseName,
                                                   Value = x.CourseId.ToString()
                                               }).ToList();
            ViewBag.course = courseList;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Review review)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            review.AppUserId = user.Id;

            _reviewService.Insert(review);
            return NoContent();
        }
    }
}
