using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Interfaces.Coffee;
using Webrew.Models.Coffees;

namespace Webrew.Managers.Interfaces
{
	public interface IHomeManager
	{
		Task<Coffee> AddCoffee(Coffee coffee);

		Task<List<Coffee>> GetCoffees();
	}
}
