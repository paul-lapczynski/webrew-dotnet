using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webrew.Data.Interfaces;
using Webrew.Interfaces.Beer;
using Webrew.Managers.Interfaces;
using Webrew.Models.Beers;

namespace Webrew.Managers
{
	public class HomeManager : IHomeManager
	{
		private readonly IBeerRepository Repository;
		public HomeManager(IBeerRepository repository)
		{
			Repository = repository;
		}

		public async Task<List<IBeer>> GetBeers()
		{
			return await Task.FromResult(Repository.GetBeers().ToList());
		}

		public List<IBeer> GetRecentBrews()
		{
			return Repository.GetBeers().Where(c => c.CreatedDate > DateTime.UtcNow.AddDays(-2)).ToList();
		}

		public async Task<IBeer> InsertBeer()
		{
			return await Repository.InsertBeer(new Beer { Name = "test", CreatedDate = DateTime.UtcNow });
		}
	}
}
