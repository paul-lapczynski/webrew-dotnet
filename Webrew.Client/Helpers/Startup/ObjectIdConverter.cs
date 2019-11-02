using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webrew_dotnet.Helpers.Startup
{
	public class ObjectIdConverter : JsonConverter<ObjectId>
	{
		public override ObjectId ReadJson(JsonReader reader, Type objectType, ObjectId existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			if (reader.Value is string strValue)
			{
				return ObjectId.Parse(strValue);
			}
			else if (reader.Value is ObjectId objectValue)
			{
				return objectValue;
			}
			else
			{
				return ObjectId.Empty;
			}
		}

		public override void WriteJson(JsonWriter writer, ObjectId value, JsonSerializer serializer)
		{
			if (value is ObjectId objectIdValue)
			{
				writer.WriteValue(objectIdValue.ToString());
			}
			else
			{
				writer.WriteValue(ObjectId.Empty.ToString());
			}
		}
	}
}
