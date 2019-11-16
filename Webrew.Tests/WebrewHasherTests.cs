using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Tests.Models;
using Xunit;

namespace Webrew.Tests
{
	public class WebrewHasherTests
	{
		[Fact]
		public void HashPassword_DifferentSalts_ShouldNotBeTheSame()
		{
			// Setup
			var saltOne = WebrewHasherTest.Instance.GetRandomSalt();
			var saltTwo = WebrewHasherTest.Instance.GetRandomSalt();
			var optionsOne = WebrewHasherTest.Instance.BuildOptionsWithSpecifiedSalt(saltOne);
			var optionsTwo = WebrewHasherTest.Instance.BuildOptionsWithSpecifiedSalt(saltTwo);

			// Act
			var hashwordOne = WebrewHasherTest.Instance.HashPassword(optionsOne.Password, optionsOne.Secret, optionsOne.Salt);
			var hashwordTwo = WebrewHasherTest.Instance.HashPassword(optionsOne.Password, optionsOne.Secret, optionsOne.Salt);

			// Assert
			hashwordOne.Should().BeSameAs(hashwordOne, "It has the same salt");
			hashwordOne.Should().NotBeSameAs(hashwordTwo, "It has different salts");
		}

		[Fact]
		public void GetRandomSalt_CalledManyTimes_ShouldBeDifferent()
		{
			// Setup
			var list = new List<byte[]>();

			// Act
			for (var i = 0; i < 100000; i++)
			{
				list.Add(WebrewHasherTest.Instance.GetRandomSalt(32));
			}

			// Assert
			list.Should().OnlyHaveUniqueItems("It should unique every time");
		}

		[Fact]
		public void VerifyPasswordMatch_IncorrectChallengingPassword_ShouldBeFalse()
		{
			var password = "PassWord123";
			var salt = WebrewHasherTest.Instance.GetRandomSalt();
			var saltStr = Encoding.UTF8.GetString(salt);

			var pashword = WebrewHasherTest.Instance.HashPassword(password, WebrewHasherTest.Instance.DefaultSecret, salt);

			var match = WebrewHasherTest.Instance.VerifyPasswordMatch(
				WebrewHasherTest.Instance.DefaultPassword,
				pashword,
				WebrewHasherTest.Instance.DefaultSecret,
				saltStr);

			match.Should().BeFalse("The challenging password is not the same");
		}

		[Fact]
		public void VerifyPasswordMatch_CorrectChallengingPassword_ShouldBeTrue()
		{
			var password = "PassWord123";
			var salt = WebrewHasherTest.Instance.GetRandomSalt();
			var saltStr = Encoding.UTF8.GetString(salt);

			var pashword = WebrewHasherTest.Instance.HashPassword(password, WebrewHasherTest.Instance.DefaultSecret, salt);

			var match = WebrewHasherTest.Instance.VerifyPasswordMatch(
				password,
				pashword,
				WebrewHasherTest.Instance.DefaultSecret,
				saltStr);

			match.Should().BeTrue("The challenging password is the same");
		}
	}
}
