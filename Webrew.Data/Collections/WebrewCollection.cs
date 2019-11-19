using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

		public async Task<T> AddAsync(T item)
		{
			await Collection.InsertOneAsync(item);
			return item;
		}

		public async Task<bool> RemoveAsync(ObjectId id)
		{
			try
			{
				var result = await Collection.DeleteOneAsync(c => c.Id == id);
				return result.DeletedCount > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

        public async Task<bool> UpdateAsync(ObjectId id, T item)
        {
            try
            {
                await Collection.FindOneAndReplaceAsync(c => c.Id == id, item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<T> GetAsync(ObjectId id)
		{
			return await Collection.AsQueryable().FirstOrDefaultAsync(d => d.Id == id);
		}

		public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predecate)
		{
			return await Collection.Find(predecate).ToListAsync();
		}
	}
}
