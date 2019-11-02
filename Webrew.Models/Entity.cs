using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Interfaces;

namespace Webrew.Models
{
	public class Entity : IEntity
	{
		public ObjectId Id { get; set; }
	}
}
