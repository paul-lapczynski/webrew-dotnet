using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Interfaces.Beer
{
	public interface IBeer
	{
		ObjectId Id { get; set; }

		string Name { get; set; }

		DateTime CreatedDate { get; set; }
	}
}
