using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Interfaces;

namespace Webrew.Models
{
	public class User : Entity, IUser
	{
		public ObjectId AccountId { get; set; }

		public string Email { get; set; }

		public string Username { get; set; }
	}
}
