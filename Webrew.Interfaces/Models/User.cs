using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Common.Interfaces;

namespace Webrew.Common.Models
{
	public class User : Entity
	{
		public ObjectId AccountId { get; set; }

		public string Email { get; set; }

		public string Username { get; set; }
	}
}
