using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Data.Interfaces;
using Webrew.Models.Beers;

namespace Webrew.Data.Collections
{
	public class ReviewCollection : IReviewCollection
	{
		public IMongoCollection<Review> Reviews { get; }

		public ReviewCollection(IDbClient client)
		{
			Reviews = client.Database.GetCollection<Review>("Reviews");
		}
	}
}
