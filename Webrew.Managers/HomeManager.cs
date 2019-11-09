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
		private readonly IBeerCollection Collection;
		public HomeManager(IBeerCollection collection)
		{
			Collection = collection;
		}

		public async Task<List<Beer>> GetBeers()
		{
			return await Collection.GetListAsync(b => true);
		}

		public async Task<Beer> AddBeer(Beer beer)
		{
			return await Collection.AddAsync(beer);
		}
	}
}
