using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Common.Models;
using Webrew.Data.Interfaces;

namespace Webrew.Data.Collections
{
	public class BeerCollection : IBeerCollection
	{
		public IMongoCollection<Beer> Beers { get; }

		public BeerCollection(IDbClient client)
		{
			Beers = client.Database.GetCollection<Beer>("Beers");
		}
	}
}
