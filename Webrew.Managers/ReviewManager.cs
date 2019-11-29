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
        private readonly IBeerCollection BeerCollection;
        public ReviewManager(IReviewCollection collection, IBeerCollection beerCollection)
		{
			Collection = collection;
            BeerCollection = beerCollection;
        }

		public async Task<List<Review>> GetReviews(ObjectId beerId)
		{
			return await Collection.GetListAsync(r => r.BeerId == beerId);
		}

		public async Task<Review> AddReview(Review review)
		{
			review.CreatedDate = DateTime.UtcNow;
			Review rtn = await Collection.AddAsync(review);
            UpdateRating(rtn.BeerId);
            return rtn;
        }

        public async Task<bool> UpdateReview(ObjectId id, Review review)
        {
            bool rtn = await Collection.UpdateAsync(id, review);
            if (rtn) {
                UpdateRating(review.BeerId);
            }
            return rtn;
        }

        public async Task<bool> RemoveReview(ObjectId id)
		{
            Review review = await Collection.GetAsync(id);
            bool rtn = await Collection.RemoveAsync(id);
            if (rtn)
            {
                UpdateRating(review.BeerId);
            }
            return rtn;
        }

        public async void UpdateRating(ObjectId beerId)
        {
            List<Review> reviews = await GetReviews(beerId);
            Beer beer = await BeerCollection.GetAsync(beerId);
            decimal rating = 0;
            foreach (Review review in reviews) {
                rating += review.Overall;
            }
            var avgRating = rating / (decimal)reviews.Count;
            beer.AvgRating = avgRating;
            await BeerCollection.UpdateAsync(beer.Id, beer);
        }
    }
}
