using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetList();
        T GetById(int id);
        void Delete(int id);
        void Insert(T entity);
        void Update(T entity);
        
    }
}
