using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Common.Models
{
	public class Beer : Entity
	{
		public string Company { get; set; }
		public string Name { get; set; }
		public string Style { get; set; }
		public decimal ABV { get; set; }
		public string SuggestedGlass { get; set; }
		public decimal AvgRating { get; set; }
		public string Description { get; set; }
		public string ImageURL { get; set; }
		public DateTime CreatedDate { get; set; }
		public string CreatedByUser { get; set; }
	}
}
