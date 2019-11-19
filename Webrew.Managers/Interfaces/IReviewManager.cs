using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Models;

namespace Webrew.Managers.Interfaces
{
	public interface IReviewManager
	{
		Task<List<Review>> GetReviews();
        
        Task<Review> AddReview(Review review);

        Task<bool> UpdateReview(ObjectId id, Review review);

        Task<bool> RemoveReview(ObjectId id);
	}
}
