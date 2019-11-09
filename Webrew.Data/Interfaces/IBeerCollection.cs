using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;
using Webrew.Common.Models;

namespace Webrew.Data.Interfaces
{
	public interface IBeerCollection: IWebrewCollection<Beer>
	{

	}
}
