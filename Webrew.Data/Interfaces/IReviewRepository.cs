using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Models;

namespace Webrew.Data.Interfaces
{
	public interface IReviewRepository
	{
		IMongoQueryable<Review> GetReviews(string BeerId);

		Task<Review> InsertReview(Review review);

        Task<Review> UpdateReview(string id, Review review);

        Task<Review> RemoveReview(string id);
	}
}