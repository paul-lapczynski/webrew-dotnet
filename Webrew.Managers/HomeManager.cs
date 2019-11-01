using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webrew.Data.Interfaces;
using Webrew.Interfaces.Coffee;
using Webrew.Managers.Interfaces;
using Webrew.Models.Coffees;

namespace Webrew.Managers
{
	public class HomeManager : IHomeManager
	{
		private readonly ICoffeeRepository Repository;
		public HomeManager(ICoffeeRepository repository)
		{
			Repository = repository;
		}

		public async Task<List<ICoffee>> GetCoffees()
		{
			return await Task.FromResult(Repository.GetCoffees().ToList());
		}

		public List<ICoffee> GetRecentBrews()
		{
			return Repository.GetCoffees().Where(c => c.CreatedDate > DateTime.UtcNow.AddDays(-2)).ToList();
		}

		public async Task<ICoffee> InsertCoffee()
		{
			return await Repository.InsertCoffee(new Coffee { Name = "test", CreatedDate = DateTime.UtcNow });
		}
	}
}
