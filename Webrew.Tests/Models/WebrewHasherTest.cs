using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Managers.Utilities;

namespace Webrew.Tests.Models
{
	public class WebrewHasherTest : WebrewHasher
	{
		private static Lazy<WebrewHasherTest> _instance => new Lazy<WebrewHasherTest>(() => new WebrewHasherTest(), true);

		public new static WebrewHasherTest Instance
		{
			get
			{
				return _instance.Value;
			}
		}

		public readonly string DefaultPassword = "Testing#123";
		public readonly string DefaultSecret = "S3cre+";

		public HashOptions BuildOptionsWithSpecifiedSalt(byte[] salt)
		{
			return new HashOptions
			{
				Password = DefaultPassword,
				Salt = salt,
				Secret = DefaultPassword
			};
		}
	}
}
