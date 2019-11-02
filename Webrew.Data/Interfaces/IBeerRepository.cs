using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webrew.Interfaces.Beer;
using Webrew.Models.Beers;

namespace Webrew.Data.Interfaces
{
	public interface IBeerRepository
	{
		IQueryable<Beer> GetBeers();

		Task<Beer> InsertBeer(Beer beer);
	}
}
