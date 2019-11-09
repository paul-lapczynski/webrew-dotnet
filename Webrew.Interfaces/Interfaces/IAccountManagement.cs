using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Common.Models;

namespace Webrew.Common.Interfaces
{
	public interface IAccountManagement
	{
		string GenerateToken(User user, TimeSpan? lifetime = null);
	}
}
