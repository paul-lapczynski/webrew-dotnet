using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Models;
using Webrew.Data.Interfaces;
using Webrew.Managers.Interfaces;

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
			return await Repository.GetBeers().ToListAsync();
		}

		public async Task<Beer> AddBeer(Beer beer)
		{
			return await Repository.InsertBeer(beer);
		}
	}
}
