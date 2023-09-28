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
	public class ReviewService : IReviewService
	{
		private readonly IGenericRepository<Review> _reviewRepository;

		public ReviewService(IGenericRepository<Review> reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public void Delete(int id)
		{
			_reviewRepository.Delete(id);
		}

		public List<Review> GetAll()
		{
			Context context = new Context();
			return context.Reviews.Include(x=>x.Course).ThenInclude(x=>x.Category).Include(x=>x.Course).ThenInclude(x=>x.Instructor).Include(x=>x.AppUser).Distinct().ToList();
		}

		public Review GetById(int id)
		{
		 return	_reviewRepository.GetById(id);
		}

		public List<Review> GetList()
		{
			return _reviewRepository.GetList();
		}

		public void Insert(Review entity)
		{
			_reviewRepository.Insert(entity);
		}

		public void Update(Review entity)
		{
			_reviewRepository.Update(entity);
		}
	}
}
