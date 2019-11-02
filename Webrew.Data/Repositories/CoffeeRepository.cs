using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webrew.Data.Interfaces;
using Webrew.Interfaces.Coffee;
using Webrew.Models.Coffees;

namespace Webrew.Data.Repositories
{
	public class CoffeeRepository : ICoffeeRepository
	{
		private readonly ICoffeeCollection Collection;
		private IMongoQueryable<Coffee> Coffees
		{
			get { return Collection.Coffees.AsQueryable(); }
		}

		public CoffeeRepository(ICoffeeCollection collection)
		{
			Collection = collection;
		}

		public IQueryable<Coffee> GetCoffees()
		{
			return from coffee in Coffees
				   select coffee;
		}

		public async Task<Coffee> InsertCoffee(Coffee coffee)
		{
			await Collection.Coffees.InsertOneAsync(coffee);
			return coffee;
		}
	}
}
