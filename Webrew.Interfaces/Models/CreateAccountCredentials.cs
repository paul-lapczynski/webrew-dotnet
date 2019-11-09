using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Common.Models
{
	public class CreateUserAccountCredentials
	{
		public string Password { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
	}
}
