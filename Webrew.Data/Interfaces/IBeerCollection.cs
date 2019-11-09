using MongoDB.Driver;
using Webrew.Common.Models;

namespace Webrew.Data.Interfaces
{
	public interface IBeerCollection
	{
		IMongoCollection<Beer> Beers { get; }
	}
}
