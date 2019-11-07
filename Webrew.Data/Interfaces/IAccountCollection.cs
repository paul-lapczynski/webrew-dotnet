using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Models;

namespace Webrew.Data.Interfaces
{
	public interface IAccountCollection : IWebrewCollection<Account>
	{
		Task<Account> Get(string username);
	}
}
