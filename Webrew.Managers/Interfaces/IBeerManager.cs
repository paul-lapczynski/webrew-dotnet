using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Interfaces.Beer;
using Webrew.Models.Beers;

namespace Webrew.Managers.Interfaces
{
	public interface IBeerManager
	{
		Task<Beer> GetBeer(string id);

        Task<Beer> UpdateBeer(string id, Beer beer);
		
		Task<Beer> RemoveBeer(string id);
	}
}
