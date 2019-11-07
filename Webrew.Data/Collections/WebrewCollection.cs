using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Data.Interfaces;
using Webrew.Interfaces;

namespace Webrew.Data.Collections
{
	public class WebrewCollection<T> : IWebrewCollection<T> where T : IEntity
	{
		public IMongoCollection<T> Collection { get; }

		public WebrewCollection(IDbClient client)
		{
			Collection = client.Database.GetCollection<T>(typeof(T).Name + "s");
		}

		public async Task<T> Add(T item)
		{
			await Collection.InsertOneAsync(item);
			return item;
		}
	}
}
