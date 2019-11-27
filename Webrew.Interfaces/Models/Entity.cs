using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Common.Interfaces;

namespace Webrew.Common.Models
{
	public class Entity
	{
		public ObjectId __id { get; set; }
		public ObjectId Id
		{
			get { return __id; }
			set
			{
				__id = value;
			}
		}
	}
}
