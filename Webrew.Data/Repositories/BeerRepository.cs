﻿using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webrew.Data.Interfaces;
using Webrew.Interfaces.Beer;
using Webrew.Models.Beers;

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

		public IMongoQueryable<Beer> GetBeer(string Id)
		{
			// TODO correct query
			//var query = new BsonDocument("_id", Id);
			//var entity = Collection.Beers.Find(query);
			//return entity;
			var items = from beer in Beers
                where beer.Name == Id
                select beer;
    
            return items;
		}

		public async Task<Beer> UpdateBeer(string Id, Beer beer)
		{
			// TODO correct update
			//var query = new BsonDocument("_id", Id); 
			//var update = Update.Set("Name", "Test");
			//await Collection.Beers.Update(query, update);
			return beer;
		}

		public async Task<Beer> RemoveBeer(string Id)
		{
			// TODO correct delete
			//var query = new BsonDocument("_id", Id);
			//Collection.Beers.Remove(query);
			return new Beer();
		}
	}
}
