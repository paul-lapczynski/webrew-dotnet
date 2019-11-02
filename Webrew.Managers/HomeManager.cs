using MongoDB.Bson;
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

		public async Task<List<Coffee>> GetCoffees()
		{
			return await Task.FromResult(Repository.GetCoffees().ToList());
		}

		public async Task<Coffee> AddCoffee(Coffee coffee)
		{
			return await Repository.InsertCoffee(coffee);
		}
	}
}
