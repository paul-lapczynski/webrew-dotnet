using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Interfaces.Beer
{
	public interface IBeer
	{
		ObjectId Id { get; set; }
		string Company { get; set; }
		string Name { get; set; }
		string Style { get; set; }
		float ABV { get; set; }
		float AvgRating { get; set; }
		string Description { get; set; }
		string ImageURL { get; set; }
		DateTime CreatedDate { get; set; }
		string CreatedByUser { get; set; }
	}
}