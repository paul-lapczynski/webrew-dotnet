using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Models;
using Webrew.Data.Interfaces;

namespace Webrew.Data.Repositories
{
	public class ReviewRepository : IReviewRepository
    {
		private readonly IReviewCollection Collection;
		private IMongoQueryable<Review> Reviews
        {
			get { return Collection.Reviews.AsQueryable(); }
		}

		public ReviewRepository(IReviewCollection collection)
		{
			Collection = collection;
		}

		public IMongoQueryable<Review> GetReviews(string BeerId)
		{
            var items = from review in Reviews
                where review.BeerId == BeerId
                select review;
    
            return items;
		}

		public async Task<Review> InsertReview(Review review)
		{
			await Collection.Reviews.InsertOneAsync(review);
			return review;
		}

		public IMongoQueryable<Review> GetReview(string id)
		{
			// TODO correct query
            //var query = new BsonDocument("_id", Id);
			//var entity = Collection.Reviews.Find(query);
			//return entity;
            var items = from review in Reviews
                where review.BeerId == id
                select review;
    
            return items;
		}

		public async Task<Review> UpdateReview(string id, Review review)
		{
			// TODO correct update
            //var query = new BsonDocument("_id", Id); 
			//var update = Update.Set("ReviewText", "Test");
			//await Collection.Reviews.Update(query, update);
			return review;
		}

		public async Task<Review> RemoveReview(string id)
		{
			// TODO correct delete
            //var query = new BsonDocument("_id", Id);
			//Collection.Reviews.Remove(query);
			//return true;
            return new Review();
		}
	}
}
