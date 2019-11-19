using FluentAssertions;
using Microsoft.IdentityModel.Logging;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Webrew.Common.Models;
using Webrew.Managers.Tests.Models;
using Xunit;

namespace Webrew.Managers.Tests
{
	public class AccountManagementTests
	{
		private JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
		public AccountManagementTests()
		{
			IdentityModelEventSource.ShowPII = true;
		}

		[Fact]
		public void GenerateToken_ValidCredentials_TokenShouldContainEmailAndUserId()
		{
			// Arrange
			var manager = new AccountManagementTest(new SecuritySettings { JwtSecret = "S3cR3+ S3cR3+ S3cR3+ S3cR3+ S3cR3+" });
			var userEmail = "John.Doe@domain.com";
			var id = ObjectId.GenerateNewId();
			var user = new User
			{
				AccountId = ObjectId.GenerateNewId(),
				Email = userEmail,
				Id = id,
				Username = "John.Doe"
			};

			// Act
			var token = manager.GenerateToken(user);
			var claims = TokenHandler.ReadJwtToken(token).Claims.ToList();
			var userClaim = ObjectId.Parse(claims.FirstOrDefault(c => c.Type == "UserId").Value);
			var emailClaim = claims.FirstOrDefault(c => c.Type == "Email").Value;

			// Assert
			userClaim.Should().BeEquivalentTo(id);
			emailClaim.Should().BeEquivalentTo(userEmail);
		}

		[Fact]
		public void GenerateToken_JwtSecretIsShort_ShouldThrowError()
		{
			// Arrange
			var manager = new AccountManagementTest(new SecuritySettings { JwtSecret = "S3cR3+" });
			var userEmail = "John.Doe@domain.com";
			var id = ObjectId.GenerateNewId();
			var user = new User
			{
				AccountId = ObjectId.GenerateNewId(),
				Email = userEmail,
				Id = id,
				Username = "John.Doe"
			};

			Func<string> act = () => manager.GenerateToken(user, TimeSpan.FromSeconds(10));

			act.Should().Throw<Exception>("Token is too short");
		}
	}
}
