using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Common.Models;
using Webrew.Data.Interfaces;

namespace Webrew.Data.Collections
{
	public class ReviewCollection : WebrewCollection<Review>, IReviewCollection
	{
		private IMongoQueryable<Review> Reviews { get { return Collection.AsQueryable(); } }
		public ReviewCollection(IDbClient client) : base(client)
		{
		}
	}
}
