using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Models;
using Webrew.Data.Interfaces;

namespace Webrew.Data.Collections
{
	public class WebrewCollection<T> : IWebrewCollection<T> where T : Entity
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
