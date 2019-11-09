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
	public class BeerManager : IBeerManager
	{
		private readonly IBeerRepository Repository;
		public BeerManager(IBeerRepository repository)
		{
			Repository = repository;
		}

		public async Task<List<Beer>> GetBeer(string id)
		{
			return await Repository.GetBeer(id).ToListAsync();
		}

		public Task<Beer> RemoveBeer(string id)
		{
			throw new NotImplementedException();
		}

		public Task<Beer> UpdateBeer(string id, Beer beer)
		{
			throw new NotImplementedException();
		}

		//public async Task<Beer> UpdateBeer(string id, Beer beer)
		//{
		//	return await Repository.UpdateBeer(Id, beer).ToListAsync();
		//}

		//public async Task<Beer> RemoveBeer(string id)
		//{
		//	return Repository.RemoveBeer(Id);
		//}

		Task<Beer> IBeerManager.GetBeer(string id)
		{
			throw new NotImplementedException();
		}
	}
}
