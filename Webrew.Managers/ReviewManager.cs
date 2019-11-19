using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Models;
using Webrew.Data.Interfaces;
using Webrew.Managers.Interfaces;

namespace Webrew.Managers
{
	public class ReviewManager : IReviewManager
	{
		private readonly IReviewCollection Collection;
		public ReviewManager(IReviewCollection collection)
		{
			Collection = collection;
		}

		public async Task<List<Review>> GetReviews()
		{
			return await Collection.GetListAsync(r => true);
		}

		public async Task<Review> AddReview(Review review)
		{
			return await Collection.AddAsync(review);
		}

        public async Task<bool> UpdateReview(ObjectId id, Review review)
        {
            return await Collection.UpdateAsync(id, review);
        }

        public async Task<bool> RemoveReview(ObjectId id)
		{
			return await Collection.RemoveAsync(id);
		}
    }
}
