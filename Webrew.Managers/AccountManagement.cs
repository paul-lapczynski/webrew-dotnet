using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Webrew.Interfaces;

namespace Webrew.Managers
{
	public class AccountManagement : IAccountManagement
	{
		private readonly ISecuritySettings Settings;
		public AccountManagement(ISecuritySettings settings)
		{
			Settings = settings;
		}

		public string GenerateToken(IUser user, TimeSpan? lifetime = null)
		{
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim("UserId", user.Id.ToString()),
					new Claim("Email", user.Email?.ToString() ?? string.Empty)
				}),
				Expires = DateTime.UtcNow.AddTicks(lifetime.HasValue ? lifetime.Value.Ticks : TimeSpan.FromDays(1).Ticks),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.JwtSecret)), SecurityAlgorithms.HmacSha256Signature)
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var securityToken = tokenHandler.CreateToken(tokenDescriptor);
			var token = tokenHandler.WriteToken(securityToken);

			return token;
		}
	}
}
