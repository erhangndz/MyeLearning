using Business.Interfaces;
using DataAccess.Concrete;
using DataAccess.Interfaces;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<Course> _courseRepository;

        public CourseService(IGenericRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void Delete(int id)
        {
          _courseRepository.Delete(id);
        }

        public List<Course> GetAll()
        {
            Context context = new Context();
            return  context.Courses.Include(x=>x.Instructor).Include(x=>x.Category).ToList();
        }

        public Course GetById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public List<Course> GetList()
        {
            return _courseRepository.GetList();
        }

        public void Insert(Course entity)
        {
            _courseRepository.Insert(entity);
        }

        public void Update(Course entity)
        {
            _courseRepository.Update(entity);
        }

    }
}
