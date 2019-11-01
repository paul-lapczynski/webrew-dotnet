using MongoDB.Driver;
using Webrew.Models.Coffees;

namespace Webrew.Data.Interfaces
{
	public interface ICoffeeCollection
	{
		IMongoCollection<Coffee> Coffees { get; }
	}
}
