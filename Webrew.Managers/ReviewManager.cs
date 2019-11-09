using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webrew.Data.Interfaces;
using Webrew.Interfaces.Beer;
using Webrew.Managers.Interfaces;
using Webrew.Models.Beers;

namespace Webrew.Managers
{
	public class ReviewManager : IReviewManager
	{
		private readonly IReviewRepository Repository;
		public ReviewManager(IReviewRepository repository)
		{
			Repository = repository;
		}

		public async Task<List<Review>> GetReviews(string BeerId)
		{
            return await Repository.GetReviews(BeerId).ToListAsync();
		}

		public async Task<Review> AddReview(Review review)
		{
			return await Repository.InsertReview(review);
		}
		
        public async Task<Review> UpdateReview(string Id, Review review)
		{
			return await Repository.UpdateReview(Id, review);
		}
        
        public async Task<Review> RemoveReview(string Id)
		{
			return await Repository.RemoveReview(Id);
		}
	}
}
