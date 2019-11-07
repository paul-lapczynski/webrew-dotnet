using Isopoh.Cryptography.Argon2;
using Isopoh.Cryptography.SecureArray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Interfaces;
using Webrew.Data.Interfaces;
using Webrew.Managers.Utilities;

namespace Webrew.Managers
{
	public class LoginManager : ILoginManager
	{
		private readonly IAccountCollection AccountCollection;
		private readonly IUserCollection UserCollection;
		private readonly ISecuritySettings SecuritySettings;

		public LoginManager(IAccountCollection accountCollection, IUserCollection userCollection, ISecuritySettings securitySettings)
		{
			AccountCollection = accountCollection;
			UserCollection = userCollection;
			SecuritySettings = securitySettings;
		}

		public async Task<User> Login(ILoginCredentials credentials)
		{
			var account = await AccountCollection.Get(credentials.Username);
			var passwordsMath = WebrewHasher.VerifyPasswordMath(credentials.Password, account.Password, SecuritySettings.PasswordHashSecret, account.Salt);

			if (passwordsMath)
			{
				return await UserCollection.Get(credentials.Username);
			}

			return await Task.FromResult<User>(null);
		}

		public async Task<IAccount> CreateAccount(ILoginCredentials credentials)
		{
			var salt = new byte[32];
			var hashword = WebrewHasher.HashPassword(credentials.Password, SecuritySettings.PasswordHashSecret, salt);

			var account = await AccountCollection.Add(new Account
			{
				Email = "",
				Password = hashword,
				Username = credentials.Username,
				Salt = Encoding.UTF8.GetString(salt)
			}); ;

			return account;
		}
	}
}
