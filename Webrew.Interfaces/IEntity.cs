using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Interfaces
{
	public interface IEntity
	{
		ObjectId Id { get; set; }
	}
}
