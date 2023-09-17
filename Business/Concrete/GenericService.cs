using Business.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;
       

        public GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
          
        }

      

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
          
        }

        public T GetById(int id)
        {
          return _genericRepository.GetById(id);
          
        }

        public List<T> GetList()
        {
          return _genericRepository.GetList();
        }

        public void Insert(T entity)
        {
            _genericRepository.Insert(entity);
           
        }

        public void Update(T entity)
        {
            _genericRepository.Update(entity);
           
        }
    }
}
