using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Common.Interfaces
{
	public interface ICreateAccountCredentials
	{
		string Password { get; set; }
		string Username { get; set; }
		string Email { get; set; }
	}
}
