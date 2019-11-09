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
using Webrew.Common.Interfaces;
using Webrew.Common.Models;

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