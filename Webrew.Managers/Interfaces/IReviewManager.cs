using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Models;

namespace Webrew.Managers.Interfaces
{
	public interface IReviewManager
	{
		Task<List<Review>> GetReviews(string BeerId);
        
        Task<Review> AddReview(Review review);

        Task<Review> UpdateReview(string id, Review review);

        Task<Review> RemoveReview(string id);
	}
}
