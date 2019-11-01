using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Data.Interfaces;
using Webrew.Models.Coffees;

namespace Webrew.Data.Collections
{
	public class CoffeeCollection : ICoffeeCollection
	{
		public IMongoCollection<Coffee> Coffees { get; }

		public CoffeeCollection(IDbClient client)
		{
			Coffees = client.Database.GetCollection<Coffee>("Coffees");
		}
	}
}
