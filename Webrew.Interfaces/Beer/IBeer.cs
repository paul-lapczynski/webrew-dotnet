using System;
using System.Collections.Generic;
using System.Text;

namespace Webrew.Interfaces.Beer
{
	public interface IBeer
	{
		Guid Id { get; set; }

		string Name { get; set; }

		DateTime CreatedDate { get; set; }
	}
}
