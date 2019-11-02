using MongoDB.Bson;
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
	public class HomeManager : IHomeManager
	{
		private readonly IBeerRepository Repository;
		public HomeManager(IBeerRepository repository)
		{
			Repository = repository;
		}

		public async Task<List<Beer>> GetBeers()
		{
			return await Task.FromResult(Repository.GetBeers().ToList());
		}

		public async Task<Beer> AddBeer(Beer beer)
		{
			return await Repository.InsertBeer(Beer);
		}
	}
}
