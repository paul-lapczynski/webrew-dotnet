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

		Task<User> CreateUserAccount(CreateUserAccountCredentials credentials);

		string GenerateToken(User user, TimeSpan? lifetime = null);

		Task<bool >AccountExists(string username, string email);
	}
}
