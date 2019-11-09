using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Common.Interfaces
{
	public interface ISecuritySettings
	{
		string JwtSecret { get; set; }
		string PasswordHashSecret { get; set; }
	}
}
