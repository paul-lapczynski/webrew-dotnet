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

		public async Task<bool> AccountExists(string username, string email)
		{
			return await Accounts.AnyAsync(a => a.Username.ToLowerInvariant() == username || a.Email.ToLowerInvariant() == email);
		}
	}
}
