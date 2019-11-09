using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Interfaces;

namespace Webrew.Models
{
	public class CreateAccountCredentials
	{
		public string Password { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
	}
}
