using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Interfaces;

namespace Webrew.Models
{
	public class Account : Entity, IAccount
	{
		public string Email { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
	}
}
