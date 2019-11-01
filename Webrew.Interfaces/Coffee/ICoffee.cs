using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Interfaces.Coffee
{
	public interface ICoffee
	{
		Guid Id { get; set; }

		string Name { get; set; }

		DateTime CreatedDate { get; set; }
	}
}
