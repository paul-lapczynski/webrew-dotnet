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
	public class BeerCollection : WebrewCollection<Beer>, IBeerCollection
	{
		private IMongoQueryable<Beer> Beers { get { return Collection.AsQueryable(); } }


		public BeerCollection(IDbClient client) : base(client)
		{
		}

		public Task<Beer> UpdateBeer(ObjectId id, Beer beer)
		{
			throw new NotImplementedException();
		}
	}
}
