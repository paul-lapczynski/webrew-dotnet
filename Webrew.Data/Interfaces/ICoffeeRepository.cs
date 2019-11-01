using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webrew.Interfaces.Coffee;
using Webrew.Models.Coffees;

namespace Webrew.Data.Interfaces
{
	public interface ICoffeeRepository
	{
		IQueryable<ICoffee> GetCoffees();

		Task<Coffee> InsertCoffee(Coffee coffee);
	}
}
