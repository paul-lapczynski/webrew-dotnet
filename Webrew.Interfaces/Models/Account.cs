using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Common.Models
{
	public class Account : Entity
	{
		public string Email { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
	}
}
