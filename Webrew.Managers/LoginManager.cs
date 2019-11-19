using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Interfaces;
using Webrew.Common.Models;
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

		public async Task<User> Login(LoginCredentials credentials)
		{
			var account = await AccountCollection.Get(credentials.Username);
			var passwordsMath = WebrewHasher.Instance.VerifyPasswordMatch(credentials.Password, account.Password, SecuritySettings.PasswordHashSecret, account.Salt);

			if (passwordsMath)
			{
				return await UserCollection.Get(credentials.Username);
			}

			return await Task.FromResult<User>(null);
		}

		public async Task<User> CreateUserAccount(CreateUserAccountCredentials credentials)
		{
			var salt = WebrewHasher.Instance.GetRandomSalt(32);
			var hashword = WebrewHasher.Instance.HashPassword(credentials.Password, SecuritySettings.PasswordHashSecret, salt);

			var account = await AccountCollection.Add(new Account
			{
				Email = credentials.Email,
				Password = hashword,
				Username = credentials.Username,
				Salt = Encoding.UTF8.GetString(salt)
			}); ;

			var user = await UserCollection.Add(new User
			{
				AccountId = account.Id,
				Email = credentials.Email,
				Username = credentials.Username
			});

			return user;
		}

		public string GenerateToken(User user, TimeSpan? lifetime = null)
		{
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim("UserId", user.Id.ToString()),
					new Claim("Email", user.Email?.ToString() ?? string.Empty)
				}),
				Expires = DateTime.UtcNow.AddTicks(lifetime.HasValue ? lifetime.Value.Ticks : TimeSpan.FromDays(1).Ticks),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecuritySettings.JwtSecret)), SecurityAlgorithms.HmacSha256Signature)
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var securityToken = tokenHandler.CreateToken(tokenDescriptor);
			var token = tokenHandler.WriteToken(securityToken);

			return token;
		}

		public async Task<bool> AccountExists(string username, string email)
		{
			return await AccountCollection.AccountExists(username, email);
		}
	}
}
