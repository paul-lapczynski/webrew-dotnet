using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Models;

namespace Webrew.Data.Interfaces
{
	public interface IAccountCollection : IWebrewCollection<Account>
	{
		Task<Account> Get(string username);

		Task<bool> AccountExists(string username, string email);
	}
}
