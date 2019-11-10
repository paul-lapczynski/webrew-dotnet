using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Webrew.Common.Models;

namespace Webrew.Data.Interfaces
{
	public interface IReviewCollection : IWebrewCollection<Review>
	{
	}
}
