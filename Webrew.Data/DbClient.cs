using MongoDB.Driver;
using Webrew.Data.Interfaces;

namespace Webrew.Data
{
	public class DbClient : IDbClient
	{
		protected readonly IDbClientOptions Options;
		protected readonly IMongoClient Client;
		public IMongoDatabase Database { get; private set; }

		public DbClient(IDbClientOptions options)
		{
			Options = options;
			Client = new MongoClient(options.ConnectionString);
			Database = Client.GetDatabase(options.DatabaseName);
		}
	}
}
