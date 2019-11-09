using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Webrew.Data.Interfaces
{
	public interface IWebrewCollection<T>
	{
		IMongoCollection<T> Collection { get; }

		Task<T> Add(T item);
	}
}
