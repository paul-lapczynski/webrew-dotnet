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
	public class BrowseManager : IBrowseManager
	{
		private readonly IBeerCollection Collection;
		public BrowseManager(IBeerCollection collection)
		{
			Collection = collection;
		}

		public async Task<List<Beer>> GetBeers()
		{
			return await Collection.GetListAsync(b => true);
		}
    }
}
