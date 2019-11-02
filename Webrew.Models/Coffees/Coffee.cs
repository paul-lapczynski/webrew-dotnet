using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Interfaces.Coffee;

namespace Webrew.Models.Coffees
{
	public class Coffee : ICoffee
	{
		public ObjectId Id { get; set; }

		public string Name { get; set; }

		public DateTime CreatedDate { get; set; }
	}
}
