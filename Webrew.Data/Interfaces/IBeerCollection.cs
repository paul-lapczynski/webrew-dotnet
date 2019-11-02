using MongoDB.Driver;
using Webrew.Models.Beers;

namespace Webrew.Data.Interfaces
{
	public interface IBeerCollection
	{
		IMongoCollection<Beer> Beers { get; }
	}
}
