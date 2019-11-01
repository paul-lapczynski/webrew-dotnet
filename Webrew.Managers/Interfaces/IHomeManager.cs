using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Interfaces.Coffee;

namespace Webrew.Managers.Interfaces
{
	public interface IHomeManager
	{
		Task<ICoffee> InsertCoffee();

		Task<List<ICoffee>> GetCoffees();
	}
}
