using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Models;
using Webrew.Data.Interfaces;

namespace Webrew.Data.Collections
{
	public class UserCollection : WebrewCollection<User>, IUserCollection
	{
		private IMongoQueryable<User> Users { get { return Collection.AsQueryable(); } }

		public UserCollection(IDbClient client) : base(client)
		{
		}

		public async Task<User> Get(string username)
		{
			return await Users.FirstOrDefaultAsync(u => u.Username == username);
		}
	}
}
