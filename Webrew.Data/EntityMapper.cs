using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Models.Coffees;

namespace Webrew.Data
{
	public static class EntityMapper
	{
		public static void RegisterCollectionMappings()
		{
			BsonSerializer.RegisterIdGenerator(typeof(ObjectId), ObjectIdGenerator.Instance);
			BsonClassMap.RegisterClassMap<Coffee>(cm =>
			{
				cm.AutoMap();
				cm.MapIdMember(m => m.Id);
			});
		}
	}
}
