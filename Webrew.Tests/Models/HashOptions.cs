using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Tests.Models
{
	public class HashOptions
	{
		public string Password { get; set; }
		public string Secret { get; set; }

		public byte[] Salt { get; set; }
	}
}
