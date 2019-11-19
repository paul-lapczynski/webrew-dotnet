using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Webrew.Managers.Utilities
{
	public class WebrewHasher
	{
		private static Lazy<WebrewHasher> _instance => new Lazy<WebrewHasher>(() => new WebrewHasher(), true);

		public static WebrewHasher Instance
		{
			get
			{
				return _instance.Value;
			}
		}

		private static Lazy<RNGCryptoServiceProvider> _rNGCryptoServiceProvider => new Lazy<RNGCryptoServiceProvider>(() => new RNGCryptoServiceProvider(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

		private static RNGCryptoServiceProvider RNGCryptoServiceProvider
		{
			get
			{
				return _rNGCryptoServiceProvider.Value;
			}
		}


		public byte[] GetRandomSalt(int length = 16)
		{
			var salt = new byte[length];

			RNGCryptoServiceProvider.GetBytes(salt);

			return salt;
		}

		public string HashPassword(string password, string secret, byte[] salt)
		{
			var passwordBytes = Encoding.UTF8.GetBytes(password);
			var secretBytes = Encoding.UTF8.GetBytes(secret);

			var config = GenerateConfig(passwordBytes, salt, secretBytes);
			string hashString;

			using (var argon2A = new Argon2(config))
			{
				using var hashA = argon2A.Hash();
				hashString = config.EncodeString(hashA.Buffer);
			}
			return hashString;
		}

		public bool VerifyPasswordMatch(string challenge, string pashword, string secret, string salt)
		{
			var config = GenerateConfig(Encoding.UTF8.GetBytes(challenge), Encoding.UTF8.GetBytes(salt), Encoding.UTF8.GetBytes(secret));

			return Argon2.Verify(pashword, config);
		}

		private Argon2Config GenerateConfig(byte[] passwordBytes, byte[] saltBytes, byte[] secretBytes)
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
