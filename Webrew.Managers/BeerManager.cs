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

		public async Task<List<Beer>> GetBeer(string Id)
		{
			return await Repository.GetBeer(Id).ToListAsync();
		}

		public async Task<Beer> UpdateBeer(string Id, Beer beer)
		{
			return await Repository.UpdateBeer(Id, beer).ToListAsync();
		}

		public async Task<Beer> RemoveBeer(string Id)
		{
			return Repository.RemoveBeer(Id);
		}
	}
}
