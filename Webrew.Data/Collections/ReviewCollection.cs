using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public Task<Review> UpdateReview(ObjectId id, Review review)
        {
            throw new NotImplementedException();
        }
    }
}
