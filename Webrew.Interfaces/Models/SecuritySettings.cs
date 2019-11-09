using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Common.Interfaces;

namespace Webrew.Common.Models
{
	public class SecuritySettings : ISecuritySettings
	{
		public string JwtSecret { get; set; }
		public string PasswordHashSecret { get; set; }
	}
}
