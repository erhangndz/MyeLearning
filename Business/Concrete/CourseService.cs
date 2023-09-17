using Business.Interfaces;
using DataAccess.Concrete;
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
        Context context = new Context();
        public void Delete(int id)
        {
          var values=   context.Courses.Find(id);
            context.Remove<Course>(values);
            context.SaveChanges();  
        }

        public List<Course> GetAll()
        {
          return  context.Courses.Include(x=>x.Instructor).Include(x=>x.Category).ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses.Find(id);
        }

        public List<Course> GetList()
        {
            return context.Courses.ToList();
        }

        public void Insert(Course entity)
        {
            context.Courses.Add(entity);
            context.SaveChanges();
        }

        public void Update(Course entity)
        {
            context.Courses.Update(entity);
            context.SaveChanges();
        }

    }
}
