using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Webrew.Interfaces;
using Webrew.Models;

namespace webrew_dotnet.Controllers
{
	public class UserManagementController : ApiControllerBase
	{
		private readonly IAccountManagement AccountManager;
		private readonly ILoginManager LoginManager;
		public UserManagementController(IAccountManagement manager, ILoginManager loginManager)
		{
			AccountManager = manager;
			LoginManager = loginManager;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginCredentials credentials)
		{
			var account = await LoginManager.Login(credentials);

			if (account != null)
			{
				var token = AccountManager.GenerateToken(account);
				//var tokenDescriptor = new SecurityTokenDescriptor
				//{
				//	Subject = new ClaimsIdentity(new Claim[] { new Claim("UserId", 1.ToString()) }),
				//	Expires = DateTime.UtcNow.AddMinutes(10),
				//	SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("092459F3-9E45-4C89-A4AA-6876F620C500 4D69FF19-560A-4E65-93BE-CD924EF9B409 F4789E36-2F4D-479E-A1DA-0BACD912D15A")), SecurityAlgorithms.HmacSha256Signature)
				//};

				//var tokenHandler = new JwtSecurityTokenHandler();
				//var securityToken = tokenHandler.CreateToken(tokenDescriptor);
				//var token = tokenHandler.WriteToken(securityToken);

				return Ok(new { token });
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpPost("CreateAccount")]
		public async Task<IActionResult> CreateAccount(CreateAccountCredentials credentials)
		{
			var user = await LoginManager.CreateAccount(credentials);

			return Ok(user);
		}

		[HttpGet("LoggedIn")]
		[Authorize]
		public async Task<IActionResult> LoggedIn()
		{
			return await Task.FromResult(Ok());
		}
	}
}