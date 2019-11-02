using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Interfaces.Beer;
using Webrew.Models.Beers;

namespace Webrew.Managers.Interfaces
{
	public interface IHomeManager
	{
		Task<Beer> AddBeer(Beer beer);

		Task<List<Beer>> GetBeers();
	}
}
