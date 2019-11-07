using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Models;

namespace Webrew.Common.Interfaces
{
	public interface ILoginManager
	{
		Task<User> Login(LoginCredentials credentials);

		Task<Account> CreateAccount(CreateAccountCredentials credentials);
	}
}
