using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Common.Interfaces
{
	public interface IAccountManagement
	{
		string GenerateToken(IUser user, TimeSpan? lifetime = null);
	}
}
