using Business.Interfaces;
using DataAccess.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;


namespace MyeLearningProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IGenericService<Category> _categoryService;
       

        public CategoryController(IGenericService<Category> categoryService)
        {
            _categoryService = categoryService;
            
        }

        public IActionResult Index()
        {
            
            var values = _categoryService.GetList();
            return View(values);
        }

        public IActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var values = _categoryService.GetById(id);
            return View(values);    
        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            category.Status = true;
            _categoryService.Insert(category);
            return RedirectToAction("Index");
        }
    }
}
