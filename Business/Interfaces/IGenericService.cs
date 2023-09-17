using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        List<T> GetList();
        T GetById(int id);
        void Delete(int id);
        void Insert(T entity);
        void Update(T entity);
    }
}
