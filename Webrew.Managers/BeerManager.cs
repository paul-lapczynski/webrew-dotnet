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
	public class BeerManager : IBeerManager
	{
		private readonly IBeerCollection Collection;
		public BeerManager(IBeerCollection collection)
		{
			Collection = collection;
		}

		public async Task<Beer> GetBeer(ObjectId id)
		{
			return await Collection.GetAsync(id);
		}

		public async Task<bool> RemoveBeer(ObjectId id)
		{
			return await Collection.RemoveAsync(id);
		}

		public Task<Beer> UpdateBeer(ObjectId id, Beer beer)
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

	}
}
