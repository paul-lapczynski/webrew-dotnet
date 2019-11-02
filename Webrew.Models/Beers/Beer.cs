using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Interfaces.Beer;

namespace Webrew.Models.Beers
{
	public class Beer : Entity, IBeer
	{
		public string Name { get; set; }

		public DateTime CreatedDate { get; set; }
	}
}
