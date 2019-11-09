using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Common.Models
{
	public class Beer : Entity
	{
		public string Name { get; set; }

		public DateTime CreatedDate { get; set; }
	}
}
