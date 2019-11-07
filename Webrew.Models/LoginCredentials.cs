using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Interfaces;

namespace Webrew.Models
{
	public class LoginCredentials : ILoginCredentials
	{
		public string Password { get; set; }
		public string Username { get; set; }
	}
}
