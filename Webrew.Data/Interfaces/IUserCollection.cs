using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Models;

namespace Webrew.Data.Interfaces
{
	public interface IUserCollection : IWebrewCollection<User>
	{
		Task<User> Get(string username);
	}
}
