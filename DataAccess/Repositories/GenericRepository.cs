using DataAccess.Concrete;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
       Context context= new Context();
       

       

        public void Delete(int id)
        {
            var values = context.Set<T>().Find(id);
            context.Remove(values);
            context.SaveChanges();
          
        }

        public T GetById(int id)
        {
           return context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
           context.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
           context.Update(entity);
            context.SaveChanges();
        }
    }
}
