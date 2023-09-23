using Business.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.VisualStudio;

namespace MyeLearningProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly IGenericService<Comment> _commentService;
        private readonly IGenericService<Course> _courseService;
        private readonly IGenericService<Instructor> _instructorService;

        public CommentController(IGenericService<Comment> commentService, IGenericService<Course> courseService, IGenericService<Instructor> instructorService)
        {
            _commentService = commentService;
            _courseService = courseService;
            _instructorService = instructorService;
        }

        public IActionResult Index()
        {
            
            return View();
        }
    }
}
