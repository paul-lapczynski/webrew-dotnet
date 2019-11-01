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
			BsonClassMap.RegisterClassMap<Coffee>(cm =>
			{
				cm.AutoMap();
				cm.MapIdMember(m => m.Id);
			});

			BsonSerializer.RegisterIdGenerator(typeof(Guid), CombGuidGenerator.Instance);
		}
	}
}
