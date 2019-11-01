using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Data.Interfaces
{
	public interface IDbClientOptions
	{
		string ConnectionString { get; set; }
		string DatabaseName { get; set; }
	}
}
