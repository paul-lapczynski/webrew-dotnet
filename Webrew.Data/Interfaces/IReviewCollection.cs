using MongoDB.Driver;
using Webrew.Common.Models;

namespace Webrew.Data.Interfaces
{
	public interface IReviewCollection
	{
		IMongoCollection<Review> Reviews { get; }
	}
}
