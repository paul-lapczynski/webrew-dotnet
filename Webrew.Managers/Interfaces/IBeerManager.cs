using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Models;

namespace Webrew.Managers.Interfaces
{
	public interface IBeerManager
	{
		Task<Beer> GetBeer(ObjectId id);

        Task<Beer> UpdateBeer(ObjectId id, Beer beer);
		
		Task<bool> RemoveBeer(ObjectId id);
	}
}
