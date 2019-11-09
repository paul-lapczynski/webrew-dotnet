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
			var user = await LoginManager.Login(credentials);

			if (user != null)
			{
				var token = AccountManager.GenerateToken(user);
				return Ok(new { token });
			}
			else
			{
				return Unauthorized();
			}
		}

		[HttpPost("CreateAccount")]
		public async Task<IActionResult> CreateAccount(CreateUserAccountCredentials credentials)
		{
			var accountExists = await LoginManager.AccountExists(credentials.Username, credentials.Email);

			if (!accountExists)
			{
				 return CreatedAtAction("CreateAccount", await LoginManager.CreateUserAccount(credentials));
			}
			else
			{
				return Problem("Account Exists", statusCode: StatusCodes.Status409Conflict);
			}
		}

		[HttpGet("LoggedIn")]
		[Authorize]
		public async Task<IActionResult> LoggedIn()
		{
			return await Task.FromResult(Ok());
		}
	}
}