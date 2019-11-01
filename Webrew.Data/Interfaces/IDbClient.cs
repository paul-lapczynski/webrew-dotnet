using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Data.Interfaces
{
	public interface IDbClient
	{
		IMongoDatabase Database { get; }
	}
}
