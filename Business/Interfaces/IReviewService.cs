using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
	public interface IReviewService:IGenericService<Review>
	{
		List<Review> GetAll();
	}
}
