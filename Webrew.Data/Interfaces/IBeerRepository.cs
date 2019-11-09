using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Models;

namespace Webrew.Data.Interfaces
{
	public interface IBeerRepository
	{
		IMongoQueryable<Beer> GetBeers();

		Task<Beer> InsertBeer(Beer beer);
	}
}
