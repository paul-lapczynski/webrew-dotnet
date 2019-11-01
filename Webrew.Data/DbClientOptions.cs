using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Data.Interfaces;

namespace Webrew.Data
{
	public class DbClientOptions : IDbClientOptions
	{
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}
}
