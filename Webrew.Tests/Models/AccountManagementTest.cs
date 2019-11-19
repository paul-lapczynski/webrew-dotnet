using System;
using System.Collections.Generic;
using System.Text;
using Webrew.Common.Interfaces;

namespace Webrew.Managers.Tests.Models
{
	public class AccountManagementTest : AccountManagement
	{
		public AccountManagementTest(ISecuritySettings settings) : base(settings) { }
	}
}
