using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Interfaces;

namespace Webrew.Models
{
	public class SecuritySettings : ISecuritySettings
	{
		public string JwtSecret { get; set; }
		public string PasswordHashSecret { get; set; }
	}
}
