using MongoDB.Driver;
using Webrew.Models.Beers;

namespace Webrew.Data.Interfaces
{
	public interface IReviewCollection
	{
		IMongoCollection<Review> Reviews { get; }
	}
}
