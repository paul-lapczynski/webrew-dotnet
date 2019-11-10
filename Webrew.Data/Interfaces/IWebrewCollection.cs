using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Webrew.Data.Interfaces
{
	public interface IWebrewCollection<T>
	{
		IMongoCollection<T> Collection { get; }
		Task<T> Add(T item);
		Task<T> AddAsync(T item);
		Task<T> GetAsync(ObjectId id);
		Task<List<T>> GetListAsync(Expression<Func<T, bool>> predecate);
		Task<bool> RemoveAsync(ObjectId id);
	}
}
