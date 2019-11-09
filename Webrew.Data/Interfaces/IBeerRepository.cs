﻿using MongoDB.Driver.Linq;
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
		IMongoQueryable<Beer> GetBeers();

		IMongoQueryable<Beer> GetBeer(string Id);

		Task<Beer> InsertBeer(Beer beer);

		Task<Beer> UpdateBeer(string Id, Beer beer);

		Task<Beer> RemoveBeer(string Id);
	}
}