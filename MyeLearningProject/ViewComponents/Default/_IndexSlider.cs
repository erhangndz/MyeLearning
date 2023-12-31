﻿using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyeLearningProject.ViewComponents.Default
{
    public class _IndexSlider:ViewComponent
    {
        private readonly IGenericService<Banner> _bannerService;

        public _IndexSlider(IGenericService<Banner> bannerService)
        {
            _bannerService = bannerService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _bannerService.GetList();
            return View(values);
        }
    }
}
