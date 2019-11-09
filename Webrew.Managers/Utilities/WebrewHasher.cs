using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Webrew.Managers.Utilities
{
	public static class WebrewHasher
	{
		public static string HashPassword(string password, string secret, byte[] salt)
		{
			var passwordBytes = Encoding.UTF8.GetBytes(password);
			var secretBytes = Encoding.UTF8.GetBytes(secret);
			new RNGCryptoServiceProvider().GetBytes(salt);

			var config = GenerateConfig(passwordBytes, salt, secretBytes);
			var argon2A = new Argon2(config);
			string hashString;
			using (var hashA = argon2A.Hash())
			{
				hashString = config.EncodeString(hashA.Buffer);
			}

			return hashString;
		}

		public static bool VerifyPasswordMath(string challenge, string pashword, string secret, string salt)
		{
			var config = GenerateConfig(Encoding.UTF8.GetBytes(challenge), Encoding.UTF8.GetBytes(salt), Encoding.UTF8.GetBytes(secret));

			return Argon2.Verify(pashword, config);
		}

		private static Argon2Config GenerateConfig(byte[] passwordBytes, byte[] saltBytes, byte[] secretBytes)
		{
			return new Argon2Config
			{
				Type = Argon2Type.DataIndependentAddressing,
				Version = Argon2Version.Nineteen,
				TimeCost = 10,
				MemoryCost = 32768,
				Lanes = 5,
				Threads = Environment.ProcessorCount,
				Password = passwordBytes,
				Salt = saltBytes,
				Secret = secretBytes,
				HashLength = 20
			};
		}
	}
}
