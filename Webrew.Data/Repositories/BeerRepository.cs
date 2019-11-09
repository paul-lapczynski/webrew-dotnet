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
	public class BeerRepository : IBeerRepository
    {
		private readonly IBeerCollection Collection;
		private IMongoQueryable<Beer> Beers
        {
			get { return Collection.Beers.AsQueryable(); }
		}

		public BeerRepository(IBeerCollection collection)
		{
			Collection = collection;
		}

		public IMongoQueryable<Beer> GetBeers()
		{
			return from beer in Beers
                   select beer;
		}

		public async Task<Beer> InsertBeer(Beer beer)
		{
			await Collection.Beers.InsertOneAsync(beer);
			return beer;
		}
	}
}
