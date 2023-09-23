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
    public class CommentService : ICommentService
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentService(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Delete(int id)
        {
            _commentRepository.Delete(id);
        }

        public List<Comment> GetAll()
        {
            Context context = new Context();
            return  context.Comments.Include(x=>x.Student).Include(x=>x.Course).ToList();
        }

        public Comment GetById(int id)
        {
          return  _commentRepository.GetById(id);
        }

        public List<Comment> GetList()
        {
           return _commentRepository.GetList();
        }

        public void Insert(Comment entity)
        {
          _commentRepository.Insert(entity);
        }

        public void Update(Comment entity)
        {
           _commentRepository.Update(entity);
        }
    }
}
