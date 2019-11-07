using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Data.Interfaces;
using Webrew.Models;

namespace Webrew.Data.Collections
{
	public class AccountCollection : WebrewCollection<Account>, IAccountCollection
	{
		private IMongoQueryable<Account> Accounts { get { return Collection.AsQueryable(); } }
		public AccountCollection(IDbClient client) : base(client)
		{
		}

		public Account AddAccount(Account account)
		{
			Collection.InsertOneAsync(account);
			return account;
		}

		public async Task<Account> Get(string username)
		{
			return await Accounts.FirstOrDefaultAsync(a => a.Username.ToLower() == username.ToLower());
		}

		public Task<bool> AccountExists(Account account)
		{
			return Accounts.AnyAsync(a => string.Equals(account.Email, a.Email, StringComparison.InvariantCultureIgnoreCase) || string.Equals(account.Username, a.Username, StringComparison.InvariantCultureIgnoreCase));
		}
	}
}
