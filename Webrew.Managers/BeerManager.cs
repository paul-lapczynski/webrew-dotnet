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

        public async Task<bool> UpdateBeer(ObjectId id, Beer beer)
		{
			return await Collection.UpdateAsync(id, beer);
		}

        public async Task<bool> RemoveBeer(ObjectId id)
        {
            return await Collection.RemoveAsync(id);
        }
    }
}
